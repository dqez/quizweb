using Microsoft.AspNetCore.Identity;
using quizweb.Models;
using quizweb.Repositories.Interfaces;
using quizweb.Services.Interfaces;
using quizweb.ViewModels.Answer;
using quizweb.ViewModels.Question;
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
                if (answers != null)
                {
                    _unitOfWork.AnswerRepository.DeleteAnswersAsync(answers);
                }

                var questions = await _unitOfWork.QuestionRepository.GetAllQuestionsByIdQSetAsync(idQset);
                if (questions != null)
                {
                    _unitOfWork.QuestionRepository.DeleteQuestionsAsync(questions);
                }

                var questionSet = await _unitOfWork.QuestionSetRepository.GetQuestionSetByIdAsync(idQset);
                if (questionSet != null)
                {
                    _unitOfWork.QuestionSetRepository.DeleteQuestionSetAsync(questionSet);
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

        public async Task<PlayQuestionSetViewModel> GetQuizAsync(int id)
        {
            var qs = await _unitOfWork.QuestionSetRepository.GetQuestionSetByIdAsync(id);
            if (qs == null)
            {
                throw new Exception($"Quiz with ID {id} not found");
            }

            var viewModel = new PlayQuestionSetViewModel
            {
                QSetId = qs.QSetId,
                QSetName = qs.QSetName,
                Description = qs.Description,
                AuthorName = qs.AuthorName,
                CategoryName = qs.Category.CategoryName,
                LevelName = qs.Level.LevelName,
                Questions = qs.Questions.Select(q => new PlayQuestionViewModel
                {
                    QuestionId = q.QuestionId,
                    QuestionText = q.QuestionText,
                    Answers = q.Answers.Select(a => new PlayAnswerViewModel
                    {
                        AnswerId = a.AnswerId,
                        AnswerText = a.AnswerText,
                    }).ToList()
                }).ToList()
            };

            return viewModel;
        }

        public async Task<PlayQuestionSetViewModel> GetRandomQuizAsync()
        {
            var qs = await _unitOfWork.QuestionSetRepository.GetQuestionSetRandomByNewGuidAsync();
            if (qs == null)
            {
                throw new Exception("GetQuestionSetRandomByNewGuid is not found");
            }
            var viewModel = new PlayQuestionSetViewModel
            {
                QSetId = qs.QSetId,
                QSetName = qs.QSetName,
                Description = qs.Description,
                AuthorName = qs.AuthorName,
                CategoryName = qs.Category.CategoryName,
                LevelName = qs.Level.LevelName,
                Questions = qs.Questions.Select(q => new PlayQuestionViewModel
                {
                    QuestionId = q.QuestionId,
                    QuestionText = q.QuestionText,
                    Answers = q.Answers.Select(a => new PlayAnswerViewModel
                    {
                        AnswerId = a.AnswerId,
                        AnswerText = a.AnswerText,
                    }).ToList()
                }).ToList()

            };
            return viewModel;
        }

        public async Task<QuizResultViewModel> SubmitQuizAsync(SubmitQuizViewModel submitModel, string username)
        {
            var listQAnswer = await _unitOfWork.QuestionSetRepository.GetCorrectAnswerSetByIdAsync(submitModel.QSetId);
            //for loop to compare answers and count correct answers: UserAnswers vs CorrectAnswers (questionid, SelectedAnswerId vs CorrectAnswerId) 
            
        }

        public Task UpdateQuizAsync(UpdateQuestionSetViewModel viewModel, string authorName)
        {
            throw new NotImplementedException();
        }

    }
}
