using CatalogService.Application.Abstractions;
using CatalogService.Application.Repositories.CatalogItem;
using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Persistence.Services
{
    public class CatalogItemService : ICatalogItemService
    {
        readonly ICatalogItemReadRepository catalogItemReadRepository;
        readonly ICatalogItemWriteRepository catalogItemWriteRepository;
        readonly CatalogSettings settings;
        public CatalogItemService(ICatalogItemReadRepository catalogItemReadRepository, ICatalogItemWriteRepository catalogItemWriteRepository, CatalogSettings settings)
        {
            this.catalogItemReadRepository = catalogItemReadRepository;
            this.catalogItemWriteRepository = catalogItemWriteRepository;
            this.settings = settings;

        }

        public async Task CreateAsync(CatalogItem entity)
        {
            await catalogItemWriteRepository.AddAsync(new()
            {
                CatalogBrandId = entity.CatalogBrandId,
                CatalogTypeId = entity.CatalogTypeId,
                Description = entity.Description,
                Name = entity.Name,
                Price = entity.Price,
                PictureFileName = entity.PictureFileName
            });
            await catalogItemWriteRepository.SaveAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            await catalogItemWriteRepository.Remove(Id);
            await catalogItemWriteRepository.SaveAsync();
        }

        public async Task<List<CatalogItem>> GetAllAsync(int page, int size)
        {
            var query = catalogItemReadRepository.GetAll();
            var totalItems = await query.CountAsync();

            var itemsOnPage = await query.OrderBy(c => c.Name)
                                                .Skip(size * page)
                                                .Take(size)
                                                .ToListAsync();

            itemsOnPage = ChangeUriPlaceHolder(itemsOnPage);

            return itemsOnPage;
        }

        public async Task<CatalogItem> GetByIdAsync(int Id)
        {
            var catalogItem = await catalogItemReadRepository.GetByIdAsync(Id);

            var baseUri = settings.PicBaseUrl;

            if (catalogItem == null)
                return null;

            catalogItem.PictureUri = baseUri + catalogItem.PictureFileName;
            return catalogItem;
        }
        public List<CatalogItem> ChangeUriPlaceHolder(List<CatalogItem> items)
        {
            var baseUri = settings.PicBaseUrl;

            foreach (var item in items)
            {
                if (item != null)
                    item.PictureUri = baseUri + item.PictureFileName;
            }
            return items;
        }

        public Task UpdateAsync(CatalogItem entity)
        {
            //todo***
        }
    }
}
