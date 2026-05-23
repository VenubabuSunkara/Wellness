using Microsoft.AspNetCore.Mvc;
using Wellness.Web.ViewModels;

namespace Wellness.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;

        public AuthController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(
            LoginViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "https://localhost:5001/api/auth/login",
                model);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(
                    "Index",
                    "Dashboard");
            }

            ViewBag.Error = "Invalid Login";

            return View(model);
        }
    }
}
