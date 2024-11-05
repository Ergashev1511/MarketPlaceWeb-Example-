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
        public async Task<long> AddProduct(Product product)
        {
            try
            {
                await _dbContext.products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return product.Id;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            try
            {
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
                return await _dbContext.products.
                    Include(s=>s.Category).ToListAsync();
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
                _dbContext.products.Update(product);
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
