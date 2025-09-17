using quizweb.Models;

namespace quizweb.Repositories.Interfaces
{
    public interface IQuestionSetRepository
    {
        Task<QuestionSet?> GetQuestionSetRandomByIdCateAndIdLevel(int idCate, int idLevel);
        Task<IEnumerable<QuestionSet>> GetAllCreatedQuestionSetsByUsernameAsync(string username);
        Task<QuestionSet?> GetQuestionSetByIdAsync(int id);
        Task AddQuestionSetAsync(QuestionSet questionSet);
        Task UpdateQuestionSetAsync(QuestionSet questionSet);
        Task DeleteQuestionSetAsync(int id);
    }
}
