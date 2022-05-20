using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Constants;
using Newtonsoft.Json;
using WebAPITest.Models;

namespace BackEnd.Controllers
{
    public class CovidController : Controller
    {
        readonly News news = new();

        public JsonResult GetCovidNews()
        {
            List<News> articles = new();
            
            foreach (var article in news.SearchNews("Covid"))
            {
                articles.Add(new News(article));
            }
            
            return Json(articles);
        }
    }
}
