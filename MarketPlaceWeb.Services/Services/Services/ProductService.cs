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
        public async Task<long> AddProduct(ProductDto productDto)
        {
            Product product = new Product
            {
                Name = productDto.Name,
                Describtion = productDto.Describtion,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
            };


            var Id = await _repository.AddProduct(product);
            return Id;
        }

        public async Task<bool> DeleteProduct(long Id)
        {
            await _repository.DeleteProduct(Id);
            return true;
        }
        public async Task<List<ProductViewModel>> GetAllProduct()
        {
            var products=await _repository.GetAllProduct();

            return products.Select(a => new ProductViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Describtion = a.Describtion,
                Price = a.Price,
                CategoryViewModel = new CategoryViewModel
                {
                    Id = a.Category?.Id ?? 0,
                    Name = a.Category?.Name ?? "Unknown",
                    Description = a.Category?.Describtion ?? "No description", 
                }
            }).ToList();

        }

        public async Task<ProductViewModel> GetProductById(long Id)
        {
            var product=await _repository.GetProductById(Id);

            ProductViewModel productViewModel = new ProductViewModel()
            {
                Name = product.Name,
                Describtion = product.Describtion,
                Price = product.Price,
                CategoryViewModel = new CategoryViewModel
                {
                    Id = product.Category?.Id ?? 0,
                    Name = product.Category?.Name ?? "Unknown",
                    Description = product.Category?.Describtion ?? "No description",
                }
            };
            
            return productViewModel;
        }

        public async Task<bool> UpdateProduct(ProductDto productDto, long Id)
        {
            Product product = new Product()
            {
                Name = productDto.Name,
                Describtion = productDto.Describtion,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId
            };
             await _repository.UpdateProduct(product,Id);

            return true;
        }
    }
}
