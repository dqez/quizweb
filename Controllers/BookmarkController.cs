using Microsoft.AspNetCore.Mvc;
using quizweb.Services.Implementations;
using quizweb.Services.Interfaces;
using quizweb.ViewModels.BookMark;

namespace quizweb.Controllers
{
    public class BookmarkController : Controller
    {
        private readonly IMarkedQuestionService _markedQuestionService;
        private readonly IProgressQuestionSetService _progressQuestionSetService;
        private readonly IQuestionSetService _questionSetService;

        public BookmarkController(IMarkedQuestionService markedQuestionService, IProgressQuestionSetService progressQuestionSetService, IQuestionSetService questionSetService)
        {
            _markedQuestionService = markedQuestionService;
            _progressQuestionSetService = progressQuestionSetService;
            _questionSetService = questionSetService;
        }
        
        public async Task<IActionResult> Index()
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            var progressList = await _progressQuestionSetService.GetAllProgressQuestionSets(username);
            var markedList = await _markedQuestionService.GetAllMarkedQuestionsAsync(username);
            var createdList = await _questionSetService.GetAllCreatedQuestionSetsAsync(username);

            var bookmarkViewModel = new BookMarkViewModel()
            {
                ProgressQuestionSetList = progressList,
                CreatedQuestionList = createdList,
                MarkedQuestionList = markedList
            };

            return View(bookmarkViewModel);
        }
    }
}
