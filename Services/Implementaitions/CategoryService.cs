using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;

namespace quizweb.Services.Implementaitions
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _categoryRepository.AddCategoryAsync(category);
        }
        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateCategoryAsync(category);
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await _categoryRepository.DeleteCategoryAsync(categoryId);
        }

        public async Task<List<Category>> GetAllCategoryAsync()
        {
            return [.. await _categoryRepository.GetAllCategoryAsync()];
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            var  cate = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (cate == null)
            {
                throw new Exception("Category not found");
            }
            return cate;

        }

    }
}
