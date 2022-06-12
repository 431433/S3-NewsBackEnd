using Microsoft.AspNetCore.Mvc;
using WebAPITest.Models;

namespace BackEnd.Controllers
{
    public class SportsController : Controller
    {
        readonly News news = new();

        public JsonResult GetMainSportArticle()
        {
            List<News> articles = new();
            int amount = 0;

            foreach (var article in news.SearchNews("Sport"))
            {
                amount += 1;
                if (articles.Count != 1)
                {
                    articles.Add(new News(article, amount));
                }
            }
            return Json(articles);
        }

       public JsonResult GetTopSportArticles()
        {
            List<News> articles = new();
            int amount = 0;

            foreach (var article in news.SearchNews("Sport"))
            {
                amount += 1;
                if (articles.Count != 4)
                {
                    articles.Add(new News(article, amount));
                }
            }
            articles.Remove(articles[0]);
            return Json(articles);
       }

        public JsonResult GetSportArticles()
        {
            List<News> articles = new();
            int amount = 0;

            foreach (var article in news.SearchNews("Sport"))
            {
                amount += 1;
                articles.Add(new News(article, amount));
            }
            for (int i = 0; i < 4; i++)
            {
                articles.Remove(articles[0]);
            }
            return Json(articles);
        }
    }
}
