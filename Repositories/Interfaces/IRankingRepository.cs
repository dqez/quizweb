using quizweb.Models;

namespace quizweb.Repositories.Interfaces
{
    public interface IRankingRepository
    {
        Task<IEnumerable<Ranking>> GetTopRankingsAsync(int topN);
        Task<Ranking?> GetUserRankingAsync(string username);
        Task CreateInitialRankingAsync(string username);
        Task UpdateUserScoreAsync(string username, int score);
    }
}
