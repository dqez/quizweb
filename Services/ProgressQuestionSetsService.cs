using quizweb.Models;
using quizweb.Repositories.Interfaces;

namespace quizweb.Services
{
    public class ProgressQuestionSetsService
    {
        private readonly IProgressQuestionSetRepository _progressQuestionSetRepository;

        public ProgressQuestionSetsService(IProgressQuestionSetRepository progressQuestionSetRepository)
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
            return await _progressQuestionSetRepository.GetProgressQuestionSetById(id);
        }
    }
}
