using CatalogService.Application.Repositories.CatalogBrand;
using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SharedServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Persistence.Repositories.CatalogBrand
{
    public class CatalogBrandReadRepostitory : ReadRepository<CatalogService.Domain.Entities.CatalogBrand>, ICatalogBrandReadRepository
    {
        public CatalogBrandReadRepostitory(DbContext context) : base(context)
        {
        }
    }
}
