using MarketPlaceWeb.DataAccess.DBContext;
using MarketPlaceWeb.DataAccess.Repositories.IRepository;
using MarketPlaceWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.DataAccess.Repositories.Repository
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly AppDbContext _dbContext;
        public ProductImageRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddImage(ProductImages productImages)
        {
            try
            {

                await _dbContext.ProductImages.AddAsync(productImages);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteImage(ProductImages productImages)
        {
            try
            {
                _dbContext.ProductImages.Remove(productImages);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;   
            }
        }

        public async Task<IEnumerable<ProductImages>> GetAllImages()
        {
            try
            {
                return await _dbContext.ProductImages.Include(a=>a.Product).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<ProductImages>();
            }
        }

        public async Task<ProductImages> GetByIdImages(long Id)
        {
            try
            {
                var productImage = await _dbContext.ProductImages.Include(a=>a.Product).FirstOrDefaultAsync(c=>c.Id==Id);
                return productImage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ProductImages();
            }
        }

        public async Task<bool> UpdateImage(ProductImages productImages, long Id)
        {

            try
            {
                 _dbContext.ProductImages.Update(productImages);
                await _dbContext.SaveChangesAsync();
                return true;
                // Xato bo'lishi mumkin Debug qilib tekshiraman
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
