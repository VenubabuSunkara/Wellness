using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Wellness.Web.Services.Interface;
using Wellness.Web.ViewModels;

namespace Wellness.Web.Controllers
{
    public class WeightController(IWeightService weightService) : Controller
    {
        private readonly IWeightService _weightService = weightService;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(WeightRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save the weight data
                await _weightService.SaveWeightAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(WeightRequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save the weight data
                await _weightService.UpdateWeightAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int WeightId)
        {
            if (ModelState.IsValid)
            {
                // Save the weight data
                await _weightService.DeleteWeightAsync(WeightId);
                return RedirectToAction("Index");
            }
            return View(WeightId);
        }
        public IActionResult WeightTracking() { return View(); }
        [HttpPost]
        public async Task<IActionResult> WeightTracking(WeightTrackingViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save the weight data
                await _weightService.SaveWeightTrackingAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
