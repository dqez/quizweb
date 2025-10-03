using quizweb.ViewModels.QuestionSet;

namespace quizweb.Services.Interfaces
{
    public interface ICreateQuiz
    {
        Task CreateQuizAsync(CreateQuestionSetViewModel viewModel, string authorName);
    }
}
