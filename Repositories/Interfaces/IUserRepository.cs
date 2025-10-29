using quizweb.Models;

namespace quizweb.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<QuestionSet>> GetCreatedQuestionSetsAsync(string username);
        Task<List<ProgressQuestionSet>> GetProgressQuestionSetsAsync(string username);
        Task<List<MarkedQuestion>> GetMarkedQuestionAsync(string username);
        Task<ApplicationUser?> GetProfileAsync(string username);
        Task UpdateProfileAsync(ApplicationUser user);
    }
}
