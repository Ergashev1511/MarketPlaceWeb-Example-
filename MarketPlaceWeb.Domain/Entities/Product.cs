using MarketPlaceWeb.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }=string.Empty;
        public string Describtion { get; set; }=string.Empty ;
        public decimal Price { get; set; }
        public long?  CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<ProductImages> ProductImages { get; set; }
    }
}
