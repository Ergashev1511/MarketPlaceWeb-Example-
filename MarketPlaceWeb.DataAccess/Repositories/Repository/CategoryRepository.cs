using MarketPlaceWeb.DataAccess.DBContext;
using MarketPlaceWeb.DataAccess.Repositories.IRepository;
using MarketPlaceWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.DataAccess.Repositories.Repository
{
    public class CategoryRepository : ICateogryRepository
    {
        private readonly AppDbContext _dbContext;
        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<bool> AddCategory(Category category)
        {
            try
            {
                if (category == null) throw new ArgumentNullException("Category is not null");
                

                var hascopy=await _dbContext.categories.AnyAsync(a=>a.CategoryName == category.CategoryName);

                if (hascopy) throw new Exception("This Category already exist");

                await _dbContext.categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteCategory(long id)
        {
            try
            {
                var category=await _dbContext.categories.FirstOrDefaultAsync(a=>a.Id==id);
                if (category == null) throw new Exception("Category not found!");
                _dbContext.categories.Remove(category);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            try
            {
                return await _dbContext.categories.Include(a=>a.products).ToListAsync();
            }
            catch 
            {
                return Enumerable.Empty<Category>();
            }
        }

        public async Task<Category> GetCategoryById(long id)
        {
            try
            {
                var category=await _dbContext.categories.FirstOrDefaultAsync(a=>a.Id==id);
                if (category == null) throw new Exception("Category not found!");

                return category;
            }
            catch
            {
                return new Category();
            }
        }

        public async Task<bool> UpdateCategory(Category category, long Id)
        {
            try
            {
                var oldCategory=await _dbContext.categories.FirstOrDefaultAsync(a=>a.Id==Id);
                if (oldCategory == null) throw new Exception("Category not found!");
                 
                oldCategory.CategoryName = category.CategoryName;
                oldCategory.Describtion = category.Describtion;

                _dbContext.categories.Update(oldCategory);
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
