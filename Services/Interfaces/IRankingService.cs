using quizweb.Models;

namespace quizweb.Services.Interfaces
{
    public interface IRankingService
    {
        Task<List<Ranking>> GetTopRankingsAsync(int topN);
        Task<Ranking?> GetUserRankingAsync(string username);
        Task CreateInitialRankingAsync(string username);
        Task UpdateUserScoreAsync(string username, int score);
    }
}
