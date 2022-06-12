using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.MockUpDAL
{
    public class MockDAL
    {
        public List<RatingDTO> Rating = new List<RatingDTO>();
        public bool RateArticle(RatingDTO rating)
        {
            if (Rating != null)
            {
                Rating.Add(rating);
                return true;
            }
            else return false;
        }

        public List<RatingDTO> GetArticleReviews(string title)
        {
            List<RatingDTO> articleReviews = new List<RatingDTO>();
            articleReviews.Add(Rating.Where(Rating.Contains(title)));
            return articleReviews;
        }

        public int GetGrades(string title)
        {
            
        }

    }
}
