using MarketPlaceWeb.Services.DTO;
using MarketPlaceWeb.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.Services.IServices
{
    public interface IProductService
    {
        Task<bool> AddProduct(ProductDto productDto);
        Task<bool> UpdateProduct(ProductDto productDto, long Id);
        Task<bool> DeleteProduct(long Id);
        Task<List<ProductViewModel>> GetAllProduct();
        Task<ProductViewModel> GetProductById(long Id);
    }

}
