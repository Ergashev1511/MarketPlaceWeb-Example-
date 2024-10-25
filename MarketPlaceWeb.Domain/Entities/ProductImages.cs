using MarketPlaceWeb.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Domain.Entities
{
    public class ProductImages : BaseEntity
    {
        public string ImageName { get; set; }

        public long?  ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
