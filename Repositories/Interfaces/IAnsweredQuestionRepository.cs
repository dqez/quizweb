using quizweb.Models;

namespace quizweb.Repositories.Interfaces
{
    public interface IAnsweredQuestionRepository
    {
        Task<List<AnsweredQuestion>> GetAllAnsweredQuestions(string username, int QSetId);
        Task<AnsweredQuestion?> GetAnsweredQuestionById(int qId);

        Task AddAnsweredQuestionAsync(AnsweredQuestion answeredQuestion);
        Task UpdateAnsweredQuestionAsync(AnsweredQuestion answeredQuestion);
        Task RemoveAnsweredQuestionAsync(AnsweredQuestion answeredQuestion);

    }
}
