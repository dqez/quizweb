using Microsoft.AspNetCore.Identity;
using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;
using quizweb.ViewModels.QuestionSet;

namespace quizweb.Services.Implementaitions
{
    public class CreateQuiz : ICreateQuiz
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateQuiz(IUnitOfWork unitOfWork)
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

            //

        }
    }
}
