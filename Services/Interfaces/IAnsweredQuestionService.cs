using quizweb.DTOs;
using quizweb.Models;

namespace quizweb.Services.Interfaces
{
    public interface IAnsweredQuestionService
    {
        Task<List<AnsweredQuestionDTO>> GetAllAnsweredQuestions(string username, int Qsetid);
        Task<AnsweredQuestion?> GetAnsweredQuestionById(int qId);

        Task AddAnsweredQuestions(List<AnsweredQuestion> answeredQuestions);
        Task UpdateAnsweredQuestions(List<AnsweredQuestion> answeredQuestions);

        Task AddAnsweredQuestion(AnsweredQuestion answeredQuestion);
        Task UpdateAnsweredQuestion(AnsweredQuestion answeredQuestion);
        Task RemoveAnsweredQuestion(int aqId);
    }
}
