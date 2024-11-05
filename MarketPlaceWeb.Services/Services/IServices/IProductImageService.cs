using MarketPlaceWeb.Services.DTO;
using MarketPlaceWeb.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.Services.IServices
{
    public interface IProductImageService
    {
        Task<bool> AddProductImage(ProductImagesDto productImagesDto);
        Task<bool> UpdateProductImage(ProductImagesDto productImagesDto,long Id);
        Task<bool> DeleteProductImage(long Id);
        Task<ProductImageViewModel> GetByIdProductImage(long Id);
        Task<List<ProductImageViewModel>> GetAllProductImages();
    }
}
