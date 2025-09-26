using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;

namespace quizweb.Repositories.Implementations
{
    public class RankingService : IRankingService
    {
        private readonly IRankingRepository _rankingRepository;

        public RankingService(IRankingRepository rankingRepository)
        {
            _rankingRepository = rankingRepository;
        }

        public async Task CreateInitialRankingAsync(string username)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            await _rankingRepository.CreateInitialRankingAsync(username);
        }

        public async Task<List<Ranking>> GetTopRankingsAsync(int topN)
        {
            return (await _rankingRepository.GetTopRankingsAsync(topN)).ToList();
        }

        public async Task<Ranking?> GetUserRankingAsync(string username)
        {
            return await _rankingRepository.GetUserRankingAsync(username);
        }

        public async Task UpdateUserScoreAsync(string username, int score)
        {
            await _rankingRepository.UpdateUserScoreAsync(username, score);
        }
    }
}
