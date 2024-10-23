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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddProduct(Product product)
        {
            try
            {
                if (product == null) throw new ArgumentNullException("Product is not null");


                var hascopy=await _dbContext.products.AnyAsync(a=>a.ProductName==product.ProductName);
                if (hascopy) throw new Exception("This Product already exist!");

                await _dbContext.products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(long Id)
        {
            try
            {
                var product=await _dbContext.products.FirstOrDefaultAsync(a=>a.Id==Id);
                if (product == null) throw new Exception("Product not found!");

                _dbContext.products.Remove(product);  
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Product>> GetAllProduct()
        {
            try
            {
                return await _dbContext.products.ToListAsync();
            }
            catch
            {
                return new List<Product>();
            }
        }

        public async Task<Product> GetProductById(long Id)
        {
           try
            {
               var product =await _dbContext.products.FirstOrDefaultAsync(a=>a.Id==Id);
                if (product == null) throw new Exception("Product not found!");

                return product;
            }
            catch
            {
                return new Product();
            }
        }

        public async Task<bool> UpdateProduct(Product product, long Id)
        {
            try
            {
                var oldProduct=await _dbContext.products.FirstOrDefaultAsync(b=>b.Id==Id);

                if (oldProduct == null) throw new Exception("Product not found!");

                oldProduct.ProductName = product.ProductName;
                oldProduct.Describtion = product.Describtion;
                oldProduct.Price = product.Price;
                oldProduct.ImageName = product.ImageName;
                oldProduct.CategoryId = product.CategoryId;

               
                _dbContext.products.Update(oldProduct);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
