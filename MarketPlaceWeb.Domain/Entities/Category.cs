using MarketPlaceWeb.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; } = string.Empty;
        public string Describtion { get; set; } = string.Empty;
        public virtual List<Product> products { get; set; }
    }
}
