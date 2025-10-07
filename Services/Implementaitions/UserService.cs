using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;

namespace quizweb.Services.Implementaitions
{
    public class UserService : IUserService
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

        public async Task<ApplicationUser> GetProfileAsync(string username)
        {
            var profile = await _userRepository.GetProfileAsync(username);
            if (profile == null)
            {
                throw new Exception("Profile is not found");
            }
            return profile;
        }

        public async Task UpdateProfileAsync(ApplicationUser user)
        {
            await _userRepository.UpdateProfileAsync(user);
        }


    }

}
