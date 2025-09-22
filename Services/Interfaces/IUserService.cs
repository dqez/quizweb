using quizweb.Models;

namespace quizweb.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<QuestionSet>> GetCreatedQuestionSetsAsync(string username);
        public Task<List<MarkedQuestion>> GetMarkedQuestionsAsync(string username);
        public Task<List<ProgressQuestionSet>> GetProgressQuestionSetsAsync(string username);
        public Task<List<Ranking>> GetRankingsAsync(int topN);
        public Task<ApplicationUser> GetProfileAsync(string username);
        public Task UpdateProfileAsync(ApplicationUser user);

    }
}
