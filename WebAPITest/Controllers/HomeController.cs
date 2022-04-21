using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAPITest.Models;

namespace WebAPITest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        News news = new();

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
            List<News> newslist = new();
            foreach (var item in news.GetNews())
            {
                newslist.Add(new News(item));
            }
            return View(newslist);
        }

        public IActionResult SearchNews()
        {
            List<News> newslist = new();
            foreach (var item in news.GetNews())
            {
                newslist.Add(new News(item));
            }
            return View(newslist);
        }
        
        [HttpGet]
        public IActionResult SearchNews(string search)
        {
            List<News> newslist = new();
            foreach (var article in news.SearchNews(search))
            {
                newslist.Add(new News(article));
            }
            return View(newslist);
        }
    }
}