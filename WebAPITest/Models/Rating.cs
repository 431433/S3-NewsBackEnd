using BackEndContract;
using BackEndFactory;
using BackEndDTO;

namespace BackEnd.Models
{
    public class Rating 
    {
        public string Comment { get; set; } 
        public string Title { get; set; }
        public int Grade { get; set; }

        private readonly IRatingDAL ratingdal;

        public Rating()
        {
            ratingdal = RatingFactory.RatingInterface();
        }

        public Rating(IRatingDAL _ratingDAL)
        {
            ratingdal = _ratingDAL;
        }

        public void RateArticle(string comment, string title, int grade)
        {
            ratingdal.RateArticle(comment, title, grade);
        }

        public List<RatingDTO> GetArticleReviews(string title)
        {
            List<RatingDTO> articleReviews = new List<RatingDTO>();
            foreach( var review in ratingdal.GetArticleReviews(title))
            {
                articleReviews.Add(new RatingDTO(review));
            }
            return articleReviews;
        }


        public int GetGrades(string title)
        {
            return ratingdal.GetGrades(title); 
        }
    }
}
