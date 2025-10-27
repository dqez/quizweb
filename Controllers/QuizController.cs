using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using quizweb.Models;
using quizweb.Services.Implementaitions;
using quizweb.Services.Interfaces;
using quizweb.ViewModels;
using quizweb.ViewModels.QuestionSet;
using System.Text.Json;

namespace quizweb.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private readonly ILogger<QuizController> _logger;
        private readonly IQuizService _quizService;
        private readonly ILevelService _levelService;
        private readonly ICategoryService _categoryService;
        private readonly IProgressQuestionSetService _progressQuestionSetService;

        public QuizController(ILogger<QuizController> logger, IQuizService quizService, ILevelService levelService, ICategoryService categoryService, IProgressQuestionSetService progressQuestionSetService)
        {
            _logger = logger;
            _quizService = quizService;
            _levelService = levelService;
            _categoryService = categoryService;
            _progressQuestionSetService = progressQuestionSetService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateQuestionSetViewModel();

            await GetAddSelectItemList(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateQuestionSetViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var username = User.Identity?.Name;
                    if (username == null)
                    {
                        return NotFound();
                    }
                    await _quizService.CreateQuizAsync(viewModel, username);
                    return RedirectToAction("Index", "Quiz");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create quiz: " + ex.Message);
                }
            }

            await GetAddSelectItemList(viewModel);
            return View(viewModel);
        }


        private async Task GetAddSelectItemList(CreateQuestionSetViewModel viewModel)
        {
            var levelList = await _levelService.GetAllLevelsAsync();
            var cateList = await _categoryService.GetAllCategoryAsync();

            viewModel.Levels = levelList.Select(l => new SelectListItem
            {
                Text = l.LevelName,
                Value = l.LevelId.ToString()
            }).ToList();

            viewModel.Categories = cateList.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString()
            }).ToList();
        }

        [HttpGet]
        public async Task<IActionResult> Play()
        {
            var viewModel = await _quizService.GetRandomQuizAsync();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Play(SubmitQuizViewModel submitQuiz)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var username = User.Identity?.Name;
                    if (username == null)
                    {
                        return NotFound();
                    }
                    var quizResultViewModel = await _quizService.SubmitQuizAsync(submitQuiz, username);
                    if (quizResultViewModel == null)
                    {
                        return NotFound();
                    }
                    //return RedirectToAction("Result", quizResultViewModel); => Redirection with complex objects: http302, objects serialized to query string, lost nested objects
                    TempData["QuizResult"] = JsonSerializer.Serialize(quizResultViewModel);
                    return RedirectToAction("Result");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error submitting quiz");
                    ModelState.AddModelError("", "An error occurred while submitting the quiz.");
                    return View(submitQuiz);
                }
            }
            return View(submitQuiz);
        }

        public IActionResult Result()
        {
            if (TempData["QuizResult"] is string json)
            {
                var viewModel = JsonSerializer.Deserialize<QuizResultViewModel>(json);
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveProgress(ProgressQuestionSetViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var username = User.Identity?.Name;
            if (username == null)
            {
                return Unauthorized();
            }

            await _progressQuestionSetService.AddProgressQuestionSet(viewModel, username);

            return NoContent();
        }
    }
}
