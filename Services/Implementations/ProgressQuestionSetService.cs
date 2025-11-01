using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;
using quizweb.ViewModels;

namespace quizweb.Services.Implementations
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
            var pQs = MapToProgressQuestionSet(viewModel, username);
            await _progressQuestionSetRepository.AddProgressQuestionSet(pQs);
        }

        public async Task UpdateProgressQuestionSet(ProgressQuestionSetViewModel viewModel, string username)
        {
            var pQs = MapToProgressQuestionSet(viewModel, username);
            await _progressQuestionSetRepository.UpdateProgressQuestionSet(pQs);
        }

        public async Task DeleteProgressQuestionSet(string username, int QSetId)
        {
            var pqs = await _progressQuestionSetRepository.GetProgressQuestionSetByUsernameAndQSetId(username, QSetId);
            if (pqs != null)
            {
                await _progressQuestionSetRepository.DeleteProgressQuestionSet(pqs);
            }
        }

        public async Task<List<ProgressQuestionSet>> GetAllProgressQuestionSets(string username)
        {
            return await _progressQuestionSetRepository.GetAllProgressQuestionSets(username);
        }

        public async Task<ProgressQuestionSet?> GetProgressQuestionSetByUsernameAndQSetId(string username, int QSetId)
        {
            var pqs = await _progressQuestionSetRepository.GetProgressQuestionSetByUsernameAndQSetId(username, QSetId);
            if (pqs == null)
            {
                throw new Exception("ProgressQuestionSet not found");
            }
            return pqs;
        }
        
        private ProgressQuestionSet MapToProgressQuestionSet(ProgressQuestionSetViewModel viewModel, string username)
        {
            return new ProgressQuestionSet()
            {
                UserName = username,
                QSetId = viewModel.QSetId,
                QuestionCount = viewModel.QuestionCount,
                QuestionLastId = viewModel.QuestionLastId,
                LastUpdated = DateTime.UtcNow //tùy là new thì nó tự init những có problem nên phải explicit set.
            };
        }

    }
}
