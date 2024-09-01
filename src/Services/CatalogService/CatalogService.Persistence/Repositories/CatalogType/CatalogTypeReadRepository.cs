using CatalogService.Application.Repositories.CatalogType;
using Microsoft.EntityFrameworkCore;
using SharedServices.Repositories;

namespace CatalogService.Persistence.Repositories.CatalogType
{
    public class CatalogTypeReadRepostitory : ReadRepository<CatalogService.Domain.Entities.CatalogType>, ICatalogTypeReadRepository
    {
        public CatalogTypeReadRepostitory(DbContext context) : base(context)
        {
        }
    }
}
