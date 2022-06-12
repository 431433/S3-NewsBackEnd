using Microsoft.AspNetCore.Mvc;
using WebAPITest.Models;

namespace BackEnd.Controllers
{
    public class NewsController : Controller
    {
        readonly News news = new();

        public JsonResult News()
        {
            int amount = 0;
            List<News> newslist = new();
            
            foreach (var item in news.GetNews())
            {
                amount += 1;
                newslist.Add(new News(item, amount));
            }
            //var Articles = JsonConvert.SerializeObject(newslist);
            
            return Json(newslist);
        }

        public JsonResult Search(string search)
        {
            int amount = 0;
            List<News> newslist = new();
            foreach (var article in news.SearchNews(search))
            {
                amount += 11;
                newslist.Add(new News(article, amount));
            }
            return Json(newslist);
        }

        public JsonResult SearchDate(string search, DateTime date)
        {
            int amount = 0;
            List<News> newslist = new();
            foreach (var article in news.SearchNewsDate(search, date))
            {
                amount += 11;
                newslist.Add(new News(article, amount));
            }
            return Json(newslist);
        }
    }
}
