using MarketPlaceWeb.DataAccess.Repositories.IRepository;
using MarketPlaceWeb.Domain.Entities;
using MarketPlaceWeb.Services.DTO;
using MarketPlaceWeb.Services.Services.IServices;
using MarketPlaceWeb.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repositorye)
        {
           _repository = repositorye;
        }
        public async Task<bool> AddProduct(ProductDto productDto)
        {
            Product product=new Product()
            {
                ProductName = productDto.ProductName,
                Describtion = productDto.Describtion,
                Price = productDto.Price,
                ImageName = productDto.ImageName,
                CategoryId = productDto.CategoryId
            };
            await _repository.AddProduct(product);
            return true;
        }

        public async Task<bool> DeleteProduct(long Id)
        {
            await _repository.DeleteProduct(Id);
            return true;
        }
        public async Task<List<ProductViewModel>> GetAllProduct()
        {
            var products=await _repository.GetAllProduct();

            return products.Select(a=> new ProductViewModel()
            {

                Id = a.Id,
                ProductName = a.ProductName,
                Describtion = a.Describtion,
                Price = a.Price,
                ImageName = a.ImageName,
                CategoryId=a.CategoryId.Value
            }).ToList();
        }

        public async Task<ProductViewModel> GetProductById(long Id)
        {
            var product=await _repository.GetProductById(Id);

            ProductViewModel productViewModel = new ProductViewModel()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Describtion = product.Describtion,
                Price = product.Price,
                ImageName = product.ImageName,
               CategoryId=product.CategoryId.Value
            };
            
            return productViewModel;
        }

        public async Task<bool> UpdateProduct(ProductDto productDto, long Id)
        {
            Product product = new Product()
            {
                ProductName = productDto.ProductName,
                Describtion = productDto.Describtion,
                Price = productDto.Price,
                ImageName = productDto.ImageName,
                CategoryId = productDto.CategoryId
            };
             await _repository.UpdateProduct(product,Id);

            return true;

        }
    }
}
