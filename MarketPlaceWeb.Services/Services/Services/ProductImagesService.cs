using FluentValidation;
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
    public class ProductImagesService : IProductImageService
    {
        private readonly IProductImageRepository _repository;
        private readonly IValidator<ProductImagesDto> _validator;   
        public ProductImagesService(IProductImageRepository repository,IValidator<ProductImagesDto> validator)
        {
            _repository = repository;
            _validator = validator;
        }
        public async Task<bool> AddProductImage(ProductImagesDto productImagesDto)
        {
            var validationResult=_validator.Validate(productImagesDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors.First().ErrorMessage);
            } 
            ProductImages productImages = new ProductImages()
            {
                ImageName = productImagesDto.ImageName, 
                ProductId = productImagesDto.ProductId,
            };
            await _repository.AddImage(productImages);
            return true;
        }

        public async Task<bool> DeleteProductImage(long Id)
        {
            if (Id <= 0)
            {
                throw new Exception("Id is low not from 0");
            }
            await _repository.DeleteImage(Id);
            return true;
        }

        public async Task<List<ProductImageViewModel>> GetAllProductImages()
        {
            var productImages=await _repository.GetAllImages();
             return productImages.Select(a=> new ProductImageViewModel()
             {
                 Id = a.Id,
                 Name=a.ImageName,
                 ProductId=a.ProductId
             }).ToList();
        }

        public async Task<ProductImageViewModel> GetByIdProductImage(long Id)
        {
            var productImage=await _repository.GetByIdImages(Id);
            ProductImageViewModel viewModel = new ProductImageViewModel()
            {
                Id=productImage.Id,
                Name=productImage.ImageName,
                ProductId=productImage.ProductId
            };
            return viewModel;
        }

        public async Task<bool> UpdateProductImage(ProductImagesDto productImagesDto, long Id)
        {
            ProductImages productImages=new ProductImages()
            {
                ImageName=productImagesDto.ImageName,
                ProductId=productImagesDto.ProductId
            };

            await _repository.UpdateImage(productImages,Id);
            return true;
        }
    }
}
