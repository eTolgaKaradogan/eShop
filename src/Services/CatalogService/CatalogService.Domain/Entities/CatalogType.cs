using SharedServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Domain.Entities
{
    public class CatalogType : BaseEntity
    {
        public string Type { get; set; }
    }
}
