using Microsoft.AspNetCore.Mvc;
using WebAPITest.Models;

namespace BackEnd.Controllers
{
    public class WarnewsController : Controller
    {
        readonly News news = new();

        public JsonResult GetWarMainArticle()
        {
            List<News> articles = new();
            int amount = 0;

            foreach (var article in news.SearchNews("War"))
            {
                amount += 1;
                if (articles.Count != 1)
                {
                    articles.Add(new News(article, amount));
                }
            }
            return Json(articles);
        }

       public JsonResult GetWarArticles()
        {
            List<News> articles = new();
            int amount = 0;

            foreach (var article in news.SearchNews("War"))
            {
                amount += 1;
                articles.Add(new News(article, amount));
            }
            articles.Remove(articles[0]);
            return Json(articles);
        }
    }
}
