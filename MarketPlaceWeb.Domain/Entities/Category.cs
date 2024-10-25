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
        public string Name { get; set; } = string.Empty;
        public string Describtion { get; set; } = string.Empty;
        public long?  ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        public virtual List<Category> ChildCategories { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
