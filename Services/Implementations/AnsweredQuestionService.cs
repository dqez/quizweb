using quizweb.DTOs;
using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;

namespace quizweb.Services.Implementations
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

        public async Task AddAnsweredQuestions(List<AnsweredQuestion> answeredQuestions)
        {
            await _answeredQuestion.AddAnsweredQuestionsAsync(answeredQuestions);
        }

        public async Task<List<AnsweredQuestionDTO>> GetAllAnsweredQuestions(string username, int QSetId)
        {
            var answeredQuestions = await _answeredQuestion.GetAllAnsweredQuestions(username, QSetId);

            return answeredQuestions.Select(aQ => new AnsweredQuestionDTO()
            {
                QuestionId = aQ.QuestionId,
                SelectedAnswerId = aQ.SelectedAnswerId
            }).ToList();
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
