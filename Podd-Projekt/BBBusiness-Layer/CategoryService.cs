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
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository categoryRepo;

        public CategoryService(CategoryRepository categoryRepository) => categoryRepo = categoryRepository;

        public async Task AddCategoryAsync(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                throw new FormatException("Category name is not valid.");
            await categoryRepo.AddAsync(category);
        }

        public async Task<Category?> GetCategoryAsync(string id)
        {
            return await categoryRepo.GetAsync(id);
        }

        public async Task<List<Category>> GetAllCategoriesAsync() => await categoryRepo.GetAllAsync();

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                throw new FormatException("Category name is not valid.");
            return await categoryRepo.UpdateAsync(category);
        }

        public async Task DeleteCategoryAsync(string id) => await categoryRepo.DeleteAsync(id);
    }
}