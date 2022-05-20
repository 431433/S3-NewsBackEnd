using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Constants;
using Newtonsoft.Json;
using WebAPITest.Models;

namespace BackEnd.Controllers
{
    public class WarnewsController : Controller
    {
        readonly News news = new();

        public JsonResult GetWarMainArticle()
        {
            List<News> articles = new();
            
            foreach (var article in news.SearchNews("War"))
            {
                if (articles.Count != 1)
                {
                    articles.Add(new News(article));
                }
            }
            //var Articles = JsonConvert.SerializeObject(newslist);
            
            return Json(articles);
        }

       public JsonResult GetWarArticles()
        {
            List<News> articles = new();

            foreach (var article in news.SearchNews("War"))
            {
                articles.Add(new News(article));
            }
            return Json(articles);
        }
    }
}
