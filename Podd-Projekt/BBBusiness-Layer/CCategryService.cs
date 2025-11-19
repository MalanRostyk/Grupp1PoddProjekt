using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCData_Access_Layer;
using DDModels;
using System.Diagnostics;

namespace BBBusiness_Layer
{
    public class CategoryService : CICategoryService
    {
        private readonly CategoryRepository categoryRepo;

        public CategoryService(CategoryRepository categoryRepository)
        {
            categoryRepo = categoryRepository;
        }

        public async Task AddCategoryAsync(Category category) => await categoryRepo.AddAsync(category);

        public async Task<Category?> GetCategoryAsync(string id)
        {
            Category? c = null;
            try
            {
                c = await categoryRepo.GetAsync(id);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return c;
        }

        public async Task<List<Category>> GetAllCategoriesAsync() => await categoryRepo.GetAllAsync();

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            bool isUpdated = false;
            try
            {
                isUpdated = await categoryRepo.UpdateAsync(category);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return isUpdated;
        }

        public async Task DeleteCategoryAsync(string id) => await categoryRepo.DeleteAsync(id);
    }
}
