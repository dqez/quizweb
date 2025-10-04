using Microsoft.AspNetCore.Identity;
using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;
using quizweb.ViewModels.QuestionSet;

namespace quizweb.Services.Implementaitions
{
    public class QuizService : IQuizService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuizService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateQuizAsync(CreateQuestionSetViewModel viewModel, string authorName)
        {
            await _unitOfWork.BeginTransactionAsync();
            var qs = new QuestionSet {
                QSetName = viewModel.QSetName,
                Description = viewModel.Description,
                AuthorName = authorName,
                LevelId = viewModel.LevelId,
                CategoryId = viewModel.CategoryId,
                CreatedTime = DateTime.Now
            };
            _unitOfWork.QuestionSetRepository.AddQuestionSetAsync

            //

        }

        public Task DeleteQuizAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetQuizAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateQuizAsync(UpdateQuestionSetViewModel viewModel, string authorName)
        {
            throw new NotImplementedException();
        }
    }
}
