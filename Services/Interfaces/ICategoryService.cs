using quizweb.Models;

namespace quizweb.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task AddCategoryAsync(Category category);
        public Task UpdateCategoryAsync(Category category);
        public Task DeleteCategoryAsync(int categoryId);
        public Task<List<Category>> GetAllCategoryAsync();
        public Task<Category> GetCategoryByIdAsync(int categoryId);


    }
}
