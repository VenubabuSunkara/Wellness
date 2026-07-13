using Microsoft.AspNetCore.Mvc;
using Wellness.Web.Services.Interface;
using Wellness.Web.ViewModels;

namespace Wellness.Web.Controllers
{
    public class AuthController(IAuthService authService) : Controller
    {
        private readonly IAuthService _authService = authService;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                var result = await _authService.LoginAsync(model);

                // Save JWT Token
                HttpContext.Session.SetString("Token", result.Token);

                // Save User Name
                HttpContext.Session.SetString("UserName", result.FullName);
                return RedirectToAction("Index", "Dashboard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }
    }
}
