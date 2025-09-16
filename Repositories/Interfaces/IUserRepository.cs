using quizweb.Models;

namespace quizweb.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Ranking>> GetTopRankingsAsync(int topN);
        Task<IEnumerable<QuestionSet>> GetCreatedQuestionSetsAsync(string username);
        Task<IEnumerable<ProgressQuestionSet>> GetProgressQuestionSetsAsync(string username);
        Task<IEnumerable<MarkedQuestion>> GetMarkedQuestionAsync(string username);
        Task<ApplicationUser> GetProfileAsync(string username);
        Task UpdateProfileAsync(ApplicationUser user);
    }
}
