﻿using MarketPlaceWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.DataAccess.Repositories.IRepository
{
    public interface ICateogryRepository
    {
        Task<bool> AddCategory(Category category);
        Task<bool> AddChildCategory(Category category);
        Task<bool> UpdateCategory(Category category,long Id);
        Task<bool> DeleteCategory(Category category);
        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> GetCategoryById(long id);
        Task<List<Category>> GetAllChildCategories(long parentId);
    }
}
