using SharedServices.Repositories.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Repositories.CatalogType
{
    public interface ICatalogTypeWriteRepository : IWriteRepository<CatalogService.Domain.Entities.CatalogType>
    {
    }
}
