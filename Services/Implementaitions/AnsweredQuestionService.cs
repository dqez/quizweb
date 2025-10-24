using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;

namespace quizweb.Services.Implementaitions
{
    public class AnsweredQuestionService : IAnsweredQuestionService
    {
        private readonly IAnsweredQuestionRepository _answeredQuestion;

        public AnsweredQuestionService(IAnsweredQuestionRepository answeredQuestion)
        {
            _answeredQuestion = answeredQuestion;
        }

        public async Task AddAnsweredQuestion(AnsweredQuestion answeredQuestion)
        {
            await _answeredQuestion.AddAnsweredQuestionAsync(answeredQuestion);
        }

        public async Task<List<AnsweredQuestion>> GetAllAnsweredQuestions(string username, int Qsetid)
        {
            return await _answeredQuestion.GetAllAnsweredQuestions(username, Qsetid);
        }

        public Task<AnsweredQuestion?> GetAnsweredQuestionById(int qId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAnsweredQuestion(int AqId)
        {
            var answeredQuestion = await _answeredQuestion.GetAnsweredQuestionById(AqId);
            if (answeredQuestion != null)
            {
                await _answeredQuestion.RemoveAnsweredQuestionAsync(answeredQuestion);
            }
        }

        public async Task UpdateAnsweredQuestion(AnsweredQuestion answeredQuestion)
        {
            await _answeredQuestion.UpdateAnsweredQuestionAsync(answeredQuestion);
        }
    }
}
