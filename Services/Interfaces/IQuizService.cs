using quizweb.ViewModels;
using quizweb.ViewModels.QuestionSet;

namespace quizweb.Services.Interfaces
{
    public interface IQuizService
    {
        Task CreateQuizAsync(CreateQuestionSetViewModel viewModel, string authorName);
        Task UpdateQuizAsync(UpdateQuestionSetViewModel viewModel, string authorName);
        Task DeleteQuizAsync(int id);

        Task<PlayQuestionSetViewModel> GetQuizAsync(int id);
        Task<QuizResultViewModel> SubmitQuizAsync(SubmitQuizViewModel submitModel, string username);
        Task SaveProgressAsync(SaveProgressViewModel saveModel, string username);
        Task<PlayQuestionSetViewModel> GetRandomQuizAsync();
    }
}
