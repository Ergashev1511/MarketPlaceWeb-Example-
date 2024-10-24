using MarketPlaceWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.DataAccess.Repositories.IRepository
{
    public interface IProductRepository
    {
        Task<long> AddProduct(Product product);
        Task<bool> UpdateProduct(Product product,long Id);
        Task<bool> DeleteProduct(long Id);
        Task<List<Product>> GetAllProduct();
        Task<Product> GetProductById(long Id);
    }
}
