using Microsoft.AspNetCore.Mvc;
using quizweb.Services.Interfaces;
using quizweb.ViewModels;

namespace quizweb.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Categories1Controller
        public async Task<ActionResult> Index()
        {
            return View(await _categoryService.GetAllCategoryAsync());
        }

        // GET: Categories1Controller/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Categories1Controller/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories1Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateViewModel cateCVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.AddCategoryAsync(cateCVM);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create category: " + ex.Message);
                }
            }
            return View(cateCVM);
        }

        // GET: Categories1Controller/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: Categories1Controller/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Categories1Controller/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Categories1Controller/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
