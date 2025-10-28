using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;

namespace quizweb.Services.Implementations
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

        public async Task<Ranking> GetUserRankingAsync(string username)
        {
            var ranking = await _rankingRepository.GetUserRankingAsync(username);
            if (ranking == null)
            {
                throw new Exception("UserRanking is not found");
            }
            return ranking;
        }

        public async Task UpdateUserScoreAsync(string username, int score)
        {
            await _rankingRepository.UpdateUserScoreAsync(username, score);
        }
    }
}
