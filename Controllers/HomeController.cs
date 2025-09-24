using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using quizweb.Models;
using quizweb.Services.Implementaitions;
using quizweb.Services.Interfaces;
using quizweb.ViewModels;

namespace quizweb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            var viewModels = categories.Select(c => new CategoryListViewModel
            {
                Name = c.CategoryName,
                Url = c.ImgUrl
            }).ToList();
            return View(viewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
