using CatalogService.Application.Repositories.CatalogItem;
using Microsoft.EntityFrameworkCore;
using SharedServices.Repositories;

namespace CatalogService.Persistence.Repositories.CatalogItem
{
    public class CatalogItemReadRepostitory : ReadRepository<CatalogService.Domain.Entities.CatalogItem>, ICatalogItemReadRepository
    {
        public CatalogItemReadRepostitory(DbContext context) : base(context)
        {
        }
    }
}
