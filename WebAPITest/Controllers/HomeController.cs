using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAPITest.Models;

namespace WebAPITest.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult News()
        {
            News news = new();
            news.GetNews();

            List<News> newslist = new();
            foreach (var item in news.GetNews())
            {
                newslist.Add(new News(item));
            }
            return View(newslist);
        }
    }
}