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
        public string ProductName { get; set; }=string.Empty;
        public string Describtion { get; set; }=string.Empty ;
        public decimal Price { get; set; }
        public string ImageName { get; set; } = string.Empty;
        public long?  CategoryId { get; set; }
        public Category? category { get; set; }
    }
}
