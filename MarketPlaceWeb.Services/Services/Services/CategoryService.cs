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
            if(categoryDto.ParentCategoryId == null || categoryDto.ParentCategoryId==0)
            {
                Category Parentcategory = new Category()
                {
                   Name = categoryDto.Name,
                   Describtion = categoryDto.Description,
                   ParentCategoryId = null,
                };
                await _repository.AddCategory(Parentcategory);
                return true;
            }

            Category ChildCategory = new Category()
            {
                Name = categoryDto.Name,
                Describtion = categoryDto.Description,
                ParentCategoryId = categoryDto.ParentCategoryId,
            };
            await _repository.AddChildCategory(ChildCategory);
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
            return categories.Select(a => new CategoryViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Describtion,
                ParentCategory = a.ParentCategory != null ? new CategoryViewModel
                {
                    Id = a.ParentCategory.Id,
                    Name = a.ParentCategory.Name,
                    Description = a.Describtion,
                } : null
            }).ToList();
        }

        public async Task<List<CategoryViewModel>> GetAllChildCategories(long parentId)
        {
            var categories = await _repository.GetAllChildCategories(parentId);
            return categories.Select(a => new CategoryViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Describtion,
                ParentCategory = a.ParentCategory != null ? new CategoryViewModel
                {
                    Id = a.ParentCategory.Id,
                    Name = a.ParentCategory.Name,
                    Description = a.Describtion,
                } : null
            }).ToList();
        }

        public async Task<CategoryViewModel> GetCategoryById(long id)
        {
           var cateogry=await _repository.GetCategoryById(id);

            CategoryViewModel categorydto = new CategoryViewModel()
            {
                Id=cateogry.Id,
                Name = cateogry.Name,
                Description = cateogry.Describtion,
                ParentCategory = cateogry.ParentCategory != null ? new CategoryViewModel
                {
                    Id = cateogry.ParentCategory.Id,
                    Name = cateogry.ParentCategory.Name,
                    Description = cateogry.Describtion,
                } : null
            };
            return categorydto;
        }

        public async Task<bool> UpdateCategory(CategoryDto categoryDto, long Id)
        {
            Category category = new Category()
            {
                Name = categoryDto.Name,
                Describtion=categoryDto.Description,
                ParentCategoryId=categoryDto.ParentCategoryId,
            };

            await _repository.UpdateCategory(category, Id);
            return true;
        }
    }
}
