using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using work_test_mvc.Models;
using work_test_mvc.Helpers;

namespace work_test_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Result()
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Result(string text_in, int increment)
        {
            var model = new ResultModel { InputString = text_in };

            model.ResultString = IncrementHelper.IncrementString(text_in, increment);

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}