using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDModels;

namespace BBBusiness_Layer
{
    public interface CICategoryService
    {
        Task AddCategoryAsync(Category category);
        Task<Category?> GetCategoryAsync(string id);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<bool> UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(string id);
    }
}
