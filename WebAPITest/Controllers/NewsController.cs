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
            List<News> newslist = new();
            foreach (var item in news.GetNews())
            {
                newslist.Add(new News(item));
            }
            string Articles = JsonConvert.SerializeObject(new
            {
                newslist
            });
            return Json(Articles);
        }

        public JsonResult Search(string search)
        {
            List<News> newslist = new();
            foreach (var article in news.SearchNews(search))
            {
                newslist.Add(new News(article));
            }
            string Articles = JsonConvert.SerializeObject(new
            {
                newslist
            });
            return Json(Articles);
        }

        public JsonResult SearchDate(string search, DateTime date)
        {
            List<News> newslist = new();
            foreach (var article in news.SearchNewsDate(search, date))
            {
                newslist.Add(new News(article));
            }
            string Articles = JsonConvert.SerializeObject(new
            {
                newslist
            });
            return Json(Articles);
        }

        public JsonResult HotTopics(string subject, DateTime date, Languages language)
        {
            List<News> newsArticles = new();
            foreach (var article in hotTopics.NavBar(Languages.EN, DateTime.Today, "War"))
            {
                newsArticles.Add(new News(article));
            }
            string hotArticles = JsonConvert.SerializeObject(new
            {
                newsArticles
            });
            return Json(hotArticles);
        }
    }
}
