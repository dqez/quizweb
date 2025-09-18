using quizweb.Models;
using quizweb.Repositories.Interfaces;

namespace quizweb.Services
{
    public class LevelService
    {
        private readonly ILevelRepository _levelRepository;

        public LevelService(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }
        public async Task AddLevelAsync(Level level)
        {
            await _levelRepository.AddLevelAsync(level);
        }

        public async Task UpdateLevelAsync(Level level)
        {
            await _levelRepository.UpdateLevelAsync(level);
        }

        public async Task DeleteLevelAsync(int id)
        {
            await _levelRepository.DeleteLevelAsync(id);
        }

        public async Task<List<Level>> GetAllLevelsAsync()
        {
            return (await _levelRepository.GetAllLevelsAsync()).ToList();
        }

        public async Task<Level> GetLevelByIdAsync(int id)
        {
            return await _levelRepository.GetLevelByIdAsync(id);
        }

    }
}
