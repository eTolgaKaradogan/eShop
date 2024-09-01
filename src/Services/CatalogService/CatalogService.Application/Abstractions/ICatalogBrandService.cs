using CatalogService.Domain.Entities;
using SharedServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Application.Abstractions
{
    public interface ICatalogBrandService : IService<CatalogBrand>
    {
    }
}
