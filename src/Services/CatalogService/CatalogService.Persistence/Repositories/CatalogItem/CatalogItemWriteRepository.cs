using CatalogService.Application.Repositories.CatalogItem;
using Microsoft.EntityFrameworkCore;
using SharedServices.Repositories;

namespace CatalogService.Persistence.Repositories.CatalogItem
{
    public class CatalogItemWriteRepository : WriteRepository<CatalogService.Domain.Entities.CatalogItem>, ICatalogItemWriteRepository
    {
        public CatalogItemWriteRepository(DbContext context) : base(context)
        {
        }
    }
}
