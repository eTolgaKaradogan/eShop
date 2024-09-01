using CatalogService.Application.Abstractions;
using CatalogService.Application.Repositories.CatalogBrand;
using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Persistence.Services
{
    public class CatalogBrandService : ICatalogBrandService
    {
        readonly ICatalogBrandReadRepository readRepository;
        readonly ICatalogBrandWriteRepository writeRepository;

        public CatalogBrandService(ICatalogBrandReadRepository readRepository, ICatalogBrandWriteRepository writeRepository)
        {
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
        }

        public Task CreateAsync(CatalogBrand entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CatalogBrand>> GetAllAsync(int page, int size)
        {
            return await readRepository.GetAll().ToListAsync();
        }

        public Task<CatalogBrand> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CatalogBrand entity)
        {
            throw new NotImplementedException();
        }
    }
}
