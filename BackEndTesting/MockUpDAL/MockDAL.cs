using BackEndContract;
using System.Collections.Generic;
using System.Linq;
using BackEndDTO;


namespace BackEndTesting.MockUpDAL
{
    public class MockDAL : IRatingDAL
    {
        public List<RatingDTO> Rating = new List<RatingDTO>();
        public void RateArticle(string comment, string title, int grade)
        {
            Rating.Add(new RatingDTO(comment, title, grade));
        }

        public List<RatingDTO> GetArticleReviews(string title)
        {
            RatingDTO[] ratings = Rating.FindAll(_title => _title.Title == title).ToArray();
            List<RatingDTO> articleReviews = new List<RatingDTO>();
            foreach (var review in ratings)
            {
                articleReviews.Add(review);
            }

            return articleReviews;
        }

        public int GetGrades(string title)
        {
            RatingDTO[] ratings = Rating.FindAll(_title => _title.Title == title).ToArray();
            List<int> grades = new List<int>();
            foreach (var grade in ratings)
            {
                grades.Add(grade.Grade);
            }

            int averageGrade = (int)Queryable.Average(grades.AsQueryable());
            return averageGrade;
        }

    }
}
