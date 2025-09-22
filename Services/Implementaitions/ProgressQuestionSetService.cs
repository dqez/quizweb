using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;

namespace quizweb.Services.Implementaitions
{
    public class ProgressQuestionSetService : IProgressQuestionSetService
    {
        private readonly IProgressQuestionSetRepository _progressQuestionSetRepository;

        public ProgressQuestionSetService(IProgressQuestionSetRepository progressQuestionSetRepository)
        {
            _progressQuestionSetRepository = progressQuestionSetRepository;
        }

        public async Task AddProgressQuestionSet(ProgressQuestionSet progressQuestionSet)
        {
            await _progressQuestionSetRepository.AddProgressQuestionSet(progressQuestionSet);
        }

        public async Task UpdateProgressQuestionSet(ProgressQuestionSet progressQuestionSet)
        {
            await _progressQuestionSetRepository.UpdateProgressQuestionSet(progressQuestionSet);
        }

        public async Task DeleteProgressQuestionSet(int id)
        {
            await _progressQuestionSetRepository.DeleteProgressQuestionSet(id);
        }

        public async Task<List<ProgressQuestionSet>> GetAllProgressQuestionSets(string username)
        {
            return (await _progressQuestionSetRepository.GetAllProgressQuestionSets(username)).ToList();
        }

        public async Task<ProgressQuestionSet> GetProgressQuestionSetById(int id)
        {
            var pqs = await _progressQuestionSetRepository.GetProgressQuestionSetById(id);
            if (pqs == null)
            {
                throw new Exception("ProgressQuestionSet not found");
            }
            return pqs;

        }
    }
}
