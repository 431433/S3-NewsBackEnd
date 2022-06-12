using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    public class ReviewController : Controller
    {
        readonly Rating _rating = new();

        [HttpPost]
        public string Rate([FromBody] Rating rating)
        {
            if (rating != null)
            {
                try
                {
                    _rating.RateArticle(rating.Comment, rating.Title, rating.Grade);
                    return "perfect";
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return "";
        }

        [HttpGet]
        public JsonResult GetReviews(string title)
        {
            List<Rating> reviews = new();

            foreach (var review in _rating.GetArticleReviews(title))
            {
                reviews.Add(review);
            }

            return Json(reviews);
        }

        [HttpGet]
        public JsonResult GetGrade(string title)
        {
            return Json(_rating.GetGrades(title));
        }
    }
}
