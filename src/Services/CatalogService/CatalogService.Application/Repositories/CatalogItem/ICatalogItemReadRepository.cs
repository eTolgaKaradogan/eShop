using SharedServices.Repositories.Bases;

namespace CatalogService.Application.Repositories.CatalogItem
{
    public interface ICatalogItemReadRepository : IReadRepository<CatalogService.Domain.Entities.CatalogItem>
    {
    }
}
