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

        public JsonResult GetReviews(string title)
        {
            List<Rating> reviews = new();

            foreach (var review in _rating.GetArticleReviews(title))
            {
                reviews.Add(review);
            }

            return Json(reviews);
        }

        public JsonResult GetGrade(string title)
        {
            _rating.GetGrades(title);

            return Json(_rating.Grade);
        }
    }
}
