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

            try
            {
                var qs = new QuestionSet
                {
                    QSetName = viewModel.QSetName,
                    Description = viewModel.Description,
                    AuthorName = authorName,
                    LevelId = viewModel.LevelId,
                    CategoryId = viewModel.CategoryId,
                    CreatedTime = DateTime.Now,
                };
                await _unitOfWork.QuestionSetRepository.AddQuestionSetAsync(qs);
                await _unitOfWork.SaveChangesAsync();

                foreach (var q in viewModel.Questions)
                {
                    var question = new Question
                    {
                        QuestionText = q.QuestionText,
                        QSetId = qs.QSetId,
                    };
                    await _unitOfWork.QuestionRepository.AddQuestionAsync(question);
                    await _unitOfWork.SaveChangesAsync();

                    foreach (var a in q.Answers)
                    {
                        var answer = new Answer
                        {
                            QuestionId = question.QuestionId,
                            AnswerText = a.AnswerText,
                            IsCorrect = a.IsCorrect,

                        };
                        await _unitOfWork.AnswerRepository.AddAnswerAsync(answer);
                    }

                }
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();

            }
            catch (Exception)
            {

                await _unitOfWork.RollbackAsync();
                throw;
            }

        }

        public async Task DeleteQuizAsync(int idQset)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var answers = await _unitOfWork.AnswerRepository.GetAllAnswersByQSetIdAsync(idQset);
                await _unitOfWork.AnswerRepository.DeleteAnswerAsync(idQset);
                var questions = _unitOfWork.QuestionRepository.GetAllQuestionsByIdQSetAsync(idQset);
                await _unitOfWork.QuestionRepository.DeleteQuestionAsync(idQset);

                var questionSet = _unitOfWork.QuestionSetRepository.DeleteQuestionSetAsync(idQset);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();

            }
            catch (Exception)
            {

                await _unitOfWork.RollbackAsync();
                throw;
            }
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
