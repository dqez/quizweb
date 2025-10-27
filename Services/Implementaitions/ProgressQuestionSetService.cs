using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;
using quizweb.ViewModels;

namespace quizweb.Services.Implementaitions
{
    public class ProgressQuestionSetService : IProgressQuestionSetService
    {
        private readonly IProgressQuestionSetRepository _progressQuestionSetRepository;

        public ProgressQuestionSetService(IProgressQuestionSetRepository progressQuestionSetRepository)
        {
            _progressQuestionSetRepository = progressQuestionSetRepository;
        }

        public async Task AddProgressQuestionSet(ProgressQuestionSetViewModel viewModel, string username)
        {
            var pQS = new ProgressQuestionSet
            {
                UserName = username,
                QSetId = viewModel.QSetId,
                QuestionCount = viewModel.QuestionCount,
                QuestionLastId = viewModel.QuestionLastId,
                LastUpdated = DateTime.UtcNow //tùy là new thì nó tự init những có problem nên phải explicit set.
            };
            await _progressQuestionSetRepository.AddProgressQuestionSet(pQS);
        }

        public async Task UpdateProgressQuestionSet(ProgressQuestionSet progressQuestionSet)
        {
            await _progressQuestionSetRepository.UpdateProgressQuestionSet(progressQuestionSet);
        }

        public async Task DeleteProgressQuestionSet(int id)
        {
            var pqs = await _progressQuestionSetRepository.GetProgressQuestionSetById(id);
            if (pqs != null)
            {
                await _progressQuestionSetRepository.DeleteProgressQuestionSet(pqs);
            }
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
