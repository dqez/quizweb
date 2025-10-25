using quizweb.Models;

namespace quizweb.Services.Interfaces
{
    public interface IAnsweredQuestionService
    {
        Task<List<AnsweredQuestion>> GetAllAnsweredQuestions(string username, int Qsetid);
        Task<AnsweredQuestion?> GetAnsweredQuestionById(int qId);

        Task AddAnsweredQuestions(List<AnsweredQuestion> answeredQuestions);
        Task AddAnsweredQuestion(AnsweredQuestion answeredQuestion);
        Task UpdateAnsweredQuestion(AnsweredQuestion answeredQuestion);
        Task RemoveAnsweredQuestion(int AqId);
    }
}
