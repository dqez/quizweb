using quizweb.Models;

namespace quizweb.Repositories.Interfaces
{
    public interface IQuestionSetRepository
    {
        Task<IEnumerable<QuestionSet>> GetAllQuestionSetsAsync();
        Task<QuestionSet> GetQuestionSetByIdAsync(int id);
        Task<QuestionSet> GetQuestionSetRandomByIdCateAndIdLevel(int idCate, int idLevel);
        Task AddQuestionSetAsync(QuestionSet questionSet);
        Task UpdateQuestionSetAsync(QuestionSet questionSet);
        Task DeleteQuestionSetAsync(int id);
    }
}
