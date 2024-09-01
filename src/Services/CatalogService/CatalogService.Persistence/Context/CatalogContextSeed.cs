﻿using CatalogService.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Polly;
using System.Globalization;
using System.IO.Compression;

namespace CatalogService.Persistence.Context
{
    public class CatalogContextSeed
    {
        public async Task SeedAsync(CatalogContext context, IWebHostEnvironment env, ILogger<CatalogContextSeed> logger)
        {
            var policy = Policy.Handle<SqlException>()
                .WaitAndRetryAsync(
                retryCount: 3,
                sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                onRetry: (exception, timeSpan, retry, ctx) =>
                {
                    logger.LogWarning(exception, $"Exception, with message {exception.Message} detected on attempt {retry} of 3");
                });

            var setupDirPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../CatalogService/CatalogService.Persistence/Setup/SeedFiles"));
            var picturePath = "Pics";

            await policy.ExecuteAsync(() => ProcessSeeding(context, setupDirPath, picturePath, logger));
        }

        private async Task ProcessSeeding(CatalogContext context, string setupDirPath, string picturePath, ILogger logger)
        {
            if (!context.CatalogBrands.Any())
            {
                await context.CatalogBrands.AddRangeAsync(GetCatalogBrandsFromFile(setupDirPath));
                await context.SaveChangesAsync();
            }

            if(!context.CatalogTypes.Any())
            {
                await context.CatalogTypes.AddRangeAsync(GetCatalogTypesFromFile(setupDirPath));
                await context.SaveChangesAsync();
            }

            if(!context.CatalogItems.Any())
            {
                await context.CatalogItems.AddRangeAsync(GetItemsFromFile(setupDirPath, context));
                await context.SaveChangesAsync();

                GetCatalogItemPictures(setupDirPath, picturePath);
            }
        }

        private IEnumerable<CatalogBrand> GetCatalogBrandsFromFile(string contentPath)
        {
            string fileName = Path.Combine(contentPath, "BrandsTextFile.txt");

            var fileContent = File.ReadAllLines(fileName);

            var list = fileContent.Select(i => new CatalogBrand()
            {
                Brand = i.Trim('"')
            }).Where(i => i != null);

            return list;
        }

        private IEnumerable<CatalogType> GetCatalogTypesFromFile(string contentPath)
        {
            string fileName = Path.Combine(contentPath, "CatalogTypes.txt");

            var fileContent = File.ReadAllLines(fileName);

            var list = fileContent.Select(i => new CatalogType()
            {
                Type = i.Trim('"')
            }).Where(i => i != null);

            return list;
        }

        private IEnumerable<CatalogItem> GetItemsFromFile(string contentPath, CatalogContext context)
        {
            string fileName = Path.Combine(contentPath, "CatalogItems.txt");

            var catalogTypeIdLookup = context.CatalogTypes.ToDictionary(ct => ct.Type, ct => ct.Id);
            var catalogBrandIdLookup = context.CatalogBrands.ToDictionary(ct => ct.Brand, ct => ct.Id);

            var fileContent = File.ReadAllLines(fileName)
                        .Skip(1) //header
                        .Select(i => i.Split(','))
                        .Select(i => new CatalogItem()
                        {
                            CatalogTypeId = catalogTypeIdLookup[i[0]],
                            CatalogBrandId = catalogBrandIdLookup[i[1]],
                            Description = i[2].Trim('"').Trim(),
                            Name = i[3].Trim('"').Trim(),
                            Price = Decimal.Parse(i[4].Trim('"').Trim(), System.Globalization.NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture),
                            PictureFileName = i[5].Trim('"').Trim(),
                            AvailableStock = string.IsNullOrEmpty(i[6]) ? 0 : int.Parse(i[6]),
                            OnReorder = Convert.ToBoolean(i[7])
                        });

            return fileContent;
        }

        private void GetCatalogItemPictures(string contentPath, string picturePath)
        {
            picturePath ??= "pics";

            if (picturePath != null)
            {
                DirectoryInfo directory = new DirectoryInfo(picturePath);
                foreach (FileInfo file in directory.GetFiles()) 
                {
                    file.Delete();
                }

                string zipFileCatalogItemPictures = Path.Combine(contentPath, "CatalogItems.zip");
                ZipFile.ExtractToDirectory(zipFileCatalogItemPictures, picturePath);
            }
        }
    }
}
