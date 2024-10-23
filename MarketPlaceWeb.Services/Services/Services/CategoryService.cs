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
    public class CategoryService : ICategoryService
    {
        private readonly ICateogryRepository _repository;
        public CategoryService(ICateogryRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> AddCategory(CategoryDto categoryDto)
        {
            Category category = new Category()
            {
                CategoryName=categoryDto.CategoryName,
                Describtion=categoryDto.Description
            };

            await _repository.AddCategory(category);
            return true;
        }

        public async Task<bool> DeleteCategory(long id)
        {
            await _repository.DeleteCategory(id);
            return true;
        }

        public async Task<List<CategoryViewModel>> GetAllCategory()
        {
            var categories=await _repository.GetAllCategory();
            return categories.Select(c => new CategoryViewModel()
            {
                Id=c.Id,
                CategoryName=c.CategoryName,
                Description=c.Describtion
            }).ToList();    
        }

        public async Task<CategoryViewModel> GetCategoryById(long id)
        {
           var cateogry=await _repository.GetCategoryById(id);

            CategoryViewModel categorydto = new CategoryViewModel()
            {
                Id=cateogry.Id,
                CategoryName = cateogry.CategoryName,
                Description= cateogry.Describtion
            };
            return categorydto;
        }

        public async Task<bool> UpdateCategory(CategoryDto categoryDto, long Id)
        {
            Category category = new Category()
            {
                CategoryName=categoryDto.CategoryName,
                Describtion=categoryDto.Description
            };

            await _repository.UpdateCategory(category, Id);
            return true;
        }
    }
}
