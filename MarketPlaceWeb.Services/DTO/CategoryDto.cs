using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.DTO
{
    public class CategoryDto
    {
        public string Name{ get; set; }=string.Empty;
        public string Description{ get; set; } = string.Empty;
        public long? ParentCategoryId { get; set; }
    }
}
