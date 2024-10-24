using MarketPlaceWeb.Domain.Entities;
using MarketPlaceWeb.Services.DTO;
using MarketPlaceWeb.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.Services.IServices
{
    public interface ICategoryService
    {
        Task<bool> AddCategory(CategoryDto categoryDto);
        Task<bool> UpdateCategory(CategoryDto categoryDto, long Id);
        Task<bool> DeleteCategory(long id);
        Task<List<CategoryViewModel>> GetAllCategory();
        Task<CategoryViewModel> GetCategoryById(long id);
        Task<List<CategoryViewModel>> GetAllChildCategories(long parentId);
    }
}
