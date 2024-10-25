using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.DTO
{
    public class ProductImagesDto
    {
        public string ImageName { get; set; } = string.Empty;
        public long? ProductId { get; set; }
    }
}
