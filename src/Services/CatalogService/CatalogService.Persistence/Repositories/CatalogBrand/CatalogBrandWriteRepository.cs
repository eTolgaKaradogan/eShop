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
    public class CatalogBrandWriteRepository : WriteRepository<CatalogService.Domain.Entities.CatalogBrand>, ICatalogBrandWriteRepository
    {
        public CatalogBrandWriteRepository(DbContext context) : base(context)
        {
        }
    }
}
