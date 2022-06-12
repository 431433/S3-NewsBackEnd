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

        public JsonResult GetCovidNewsLatest()
        {
            int amount = 0;
            List<News> articles = new();
            
            foreach (var article in news.SearchNewsLatest("Covid"))
            {
                amount += 1;
                articles.Add(new News(article, amount));
            }
            
            return Json(articles);
        }

        public JsonResult GetCovidNewsPopular()
        {
            int amount = 0;
            List<News> articles = new();

            foreach (var article in news.SearchNews("Covid"))
            {
                amount += 1;
                articles.Add(new News(article, amount));
            }

            return Json(articles);
        }
    }
}
