using CatalogService.Application.Repositories.CatalogType;
using Microsoft.EntityFrameworkCore;
using SharedServices.Repositories;

namespace CatalogService.Persistence.Repositories.CatalogType
{
    public class CatalogTypeWriteRepostitory : WriteRepository<CatalogService.Domain.Entities.CatalogType>, ICatalogTypeWriteRepository
    {
        public CatalogTypeWriteRepostitory(DbContext context) : base(context)
        {
        }
    }
}
