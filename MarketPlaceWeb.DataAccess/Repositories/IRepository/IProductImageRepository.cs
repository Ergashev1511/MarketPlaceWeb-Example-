using MarketPlaceWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.DataAccess.Repositories.IRepository
{
    public interface IProductImageRepository
    {
        Task<bool>  AddImage(ProductImages productImages);
        Task<bool> UpdateImage(ProductImages productImages, long Id);
        Task<bool> DeleteImage(long Id);
        Task<ProductImages> GetByIdImages(long Id);
        Task<IEnumerable<ProductImages>> GetAllImages();

    }
}
