using CatalogService.Application.Abstractions;
using CatalogService.Application.Repositories.CatalogType;
using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Persistence.Services
{
    public class CatalogTypeService : ICatalogTypeService
    {
        readonly ICatalogTypeReadRepository catalogTypeReadRepository;
        readonly ICatalogTypeWriteRepository catalogTypeWriteRepository;
        public CatalogTypeService(ICatalogTypeReadRepository catalogTypeReadRepository, ICatalogTypeWriteRepository catalogTypeWriteRepository)
        {
            this.catalogTypeReadRepository = catalogTypeReadRepository;
            this.catalogTypeWriteRepository = catalogTypeWriteRepository;
        }

        public Task CreateAsync(CatalogType entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CatalogType>> GetAllAsync(int page, int size)
        {
            return await catalogTypeReadRepository.GetAll().ToListAsync();
        }

        public Task<CatalogType> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CatalogType entity)
        {
            throw new NotImplementedException();
        }
    }
}
