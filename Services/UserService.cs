using quizweb.Models;
using quizweb.Repositories.Interfaces;

namespace quizweb.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<QuestionSet>> GetCreatedQuestionSetsAsync(string username)
        {
            return (await _userRepository.GetCreatedQuestionSetsAsync(username)).ToList();
        }

        public async Task<List<MarkedQuestion>> GetMarkedQuestionsAsync(string username)
        {
            return (await _userRepository.GetMarkedQuestionAsync(username)).ToList();
        }

        public async Task<List<ProgressQuestionSet>> GetProgressQuestionSetsAsync(string username)
        {
            return (await _userRepository.GetProgressQuestionSetsAsync(username)).ToList();
        }

        public async Task<List<Ranking>> GetRankingsAsync(int topN)
        {
            return (await _userRepository.GetTopRankingsAsync(topN)).ToList();
        }

        public async Task<ApplicationUser> GetProfileAsync(string username)
        {
            return await _userRepository.GetProfileAsync(username);
        }

        public async Task UpdateProfileAsync(ApplicationUser user)
        {
            await _userRepository.UpdateProfileAsync(user);
        }


    }

}
