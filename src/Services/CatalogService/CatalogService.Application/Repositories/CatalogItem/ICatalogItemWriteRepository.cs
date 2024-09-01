using SharedServices.Repositories.Bases;

namespace CatalogService.Application.Repositories.CatalogItem
{
    public interface ICatalogItemWriteRepository : IWriteRepository<CatalogService.Domain.Entities.CatalogItem>
    {
    }
}
