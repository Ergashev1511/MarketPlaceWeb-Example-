using MarketPlaceWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.ViewModels
{
    public class ProductViewModel
    {
        public long  Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Describtion { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public CategoryViewModel?  CategoryViewModel { get; set; }
    }
}
