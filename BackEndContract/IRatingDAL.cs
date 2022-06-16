using BackEndDTO;
namespace BackEndContract
{
    public interface IRatingDAL
    {
        List<RatingDTO> GetArticleReviews(string title);
        int GetGrades(string title);
        void RateArticle(string comment, string title, int grade);
    }
}