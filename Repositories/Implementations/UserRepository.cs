using quizweb.Models;
using quizweb.Repositories.Interfaces;

namespace quizweb.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        public Task<IEnumerable<QuestionSet>> GetCreatedQuestionSetsAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MarkedQuestion>> GetMarkedQuestionAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetProfileAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProgressQuestionSet>> GetProgressQuestionSetsAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ranking>> GetTopRankingsAsync(int topN)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProfileAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
