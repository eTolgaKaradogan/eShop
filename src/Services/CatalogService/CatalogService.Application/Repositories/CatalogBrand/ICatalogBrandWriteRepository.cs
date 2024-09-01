using SharedServices.Repositories.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Repositories.CatalogBrand
{
    public interface ICatalogBrandWriteRepository : IWriteRepository<CatalogService.Domain.Entities.CatalogBrand>
    {
    }
}
