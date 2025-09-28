using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quizweb.Services.Interfaces;
using quizweb.ViewModels;

namespace quizweb.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IUserService _userService;

        public ProfileController(ILogger<ProfileController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }


        // GET: ProfileController
        public async Task<IActionResult> Index()
        {
            if(!User.Identity?.IsAuthenticated ==true)
            {
                return Unauthorized();
            }
            var username = User.Identity?.Name!;
            var user = await _userService.GetProfileAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new UserEditViewModel
            {
                Username = user.UserName!,
                Birthday = user.BirthDay,
                Email = user.Email!,
                Fullname = user.FullName,
                Sex = user.Sex,
            };
            return View(viewModel);
        }

        // GET: ProfileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: ProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
