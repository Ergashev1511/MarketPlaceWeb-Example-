using MarketPlaceWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.ViewModels
{
    public class CategoryViewModel
    {
        public long  Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CategoryViewModel? ParentCategory { get; set; }
    }
}
