using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Constants;
using Newtonsoft.Json;
using WebAPITest.Models;

namespace BackEnd.Controllers
{
    public class NewsController : Controller
    {
        readonly News news = new();
        readonly HotTopics hotTopics = new();

        public JsonResult News()
        {
            int amount = 0;
            List<News> newslist = new();
            
            foreach (var item in news.GetNews())
            {
                amount += 11;
                newslist.Add(new News(item, amount));
            }
            //var Articles = JsonConvert.SerializeObject(newslist);
            
            return Json(newslist);
        }

        public JsonResult Search(string search)
        {
            List<News> newslist = new();
            foreach (var article in news.SearchNews(search))
            {
                newslist.Add(new News(article));
            }
            var Articles = JsonConvert.SerializeObject(newslist);

            return Json(Articles);
        }

        public JsonResult SearchDate(string search, DateTime date)
        {
            List<News> newslist = new();
            foreach (var article in news.SearchNewsDate(search, date))
            {
                newslist.Add(new News(article));
            }
            var Articles = JsonConvert.SerializeObject(newslist);

            return Json(Articles);
        }

        public JsonResult HotTopics(string subject, DateTime date, Languages language)
        {
            List<News> newsArticles = new();
            foreach (var article in hotTopics.NavBar(Languages.EN, DateTime.Today, "War"))
            {
                newsArticles.Add(new News(article));
            }
            var Articles = JsonConvert.SerializeObject(newsArticles);

            return Json(Articles);
        }
    }
}
