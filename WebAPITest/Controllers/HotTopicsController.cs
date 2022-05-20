using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Constants;
using Newtonsoft.Json;
using WebAPITest.Models;

namespace BackEnd.Controllers
{
    public class HotTopicsController : Controller
    {
        readonly News news = new();

        public JsonResult GetHotTopics()
        {
            List<News> articles = new();
            
            foreach (var article in news.GetNews())
            {
                articles.Add(new News(article));
            }
            
            return Json(articles);
        }
    }
}
