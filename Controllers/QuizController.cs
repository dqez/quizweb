using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public QuizController(ILogger<QuizController> logger, IQuizService quizService)
        {
            _logger = logger;
            _quizService = quizService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
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
