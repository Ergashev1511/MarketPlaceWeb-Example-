using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.DTO
{
    public class ProductDto
    {
        public string ProductName { get; set; } = string.Empty;
        public string Describtion { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageName { get; set; } = string.Empty;
        public long? CategoryId { get; set; }
    }
}
