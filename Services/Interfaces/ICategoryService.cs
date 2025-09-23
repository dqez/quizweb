using quizweb.Models;
using quizweb.ViewModels;

namespace quizweb.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task AddCategoryAsync(CategoryCreateViewModel category);
        public Task UpdateCategoryAsync(Category category);
        public Task DeleteCategoryAsync(int categoryId);
        public Task<List<Category>> GetAllCategoryAsync();
        public Task<Category> GetCategoryByIdAsync(int categoryId);


    }
}
