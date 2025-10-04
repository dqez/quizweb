using quizweb.ViewModels.QuestionSet;

namespace quizweb.Services.Interfaces
{
    public interface IQuizService
    {
        Task CreateQuizAsync(CreateQuestionSetViewModel viewModel, string authorName);
        Task UpdateQuizAsync(UpdateQuestionSetViewModel viewModel, string authorName);
        Task DeleteQuizAsync(int id);

        Task GetQuizAsync(int id);
    }
}
