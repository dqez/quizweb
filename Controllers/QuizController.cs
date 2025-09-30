using Microsoft.AspNetCore.Mvc;
using quizweb.Services.Interfaces;

namespace quizweb.Controllers
{
    public class QuizController : Controller
    {
        private readonly ILogger<QuizController> _logger;
        private readonly IQuestionSetService _qsService;

        public QuizController(ILogger<QuizController> logger, IQuestionSetService qsService)
        {
            _logger = logger;
            _qsService = qsService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
