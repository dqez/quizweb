using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using quizweb.Services.Implementaitions;
using quizweb.Services.Interfaces;
using quizweb.ViewModels.QuestionSet;

namespace quizweb.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        private readonly ILogger<QuizController> _logger;
        private readonly IQuizService _quizService;
        private readonly ILevelService _levelService;
        private readonly ICategoryService _categoryService;

        public QuizController(ILogger<QuizController> logger, IQuizService quizService, ILevelService levelService, ICategoryService categoryService)
        {
            _logger = logger;
            _quizService = quizService;
            _levelService = levelService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var levelList = await _levelService.GetAllLevelsAsync();
            var cateList = await _categoryService.GetAllCategoryAsync();
            var viewModel = new CreateQuestionSetViewModel
            {
                Levels = levelList.Select(l => new SelectListItem
                {
                    Text = l.LevelName,
                    Value = l.LevelId.ToString()
                }).ToList(),
                Categories = cateList.Select(c => new SelectListItem
                {
                    Text = c.CategoryName,
                    Value = c.CategoryId.ToString()
                }).ToList()
            };
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

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create quiz: " + ex.Message);
                    return View(viewModel);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
