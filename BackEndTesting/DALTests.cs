using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.Models;
using BackEndTesting.MockUpDAL;

namespace BackEndTesting
{
    [TestClass()]
    public class DALTests
    {
        MockDAL mockDAL;
        Rating rating;
       [TestInitialize]
       public void NewDAL()
        {
            mockDAL = new();
            rating = new(mockDAL);
        }

        [TestMethod]
        public void AddRating()
        {
            rating.RateArticle("Perfect", "News", 10);

            Assert.AreEqual(1, mockDAL.Rating.Count);
        }

        [TestMethod]
        public void FindArticle()
        {
            rating.RateArticle("Perfect", "News", 10);
            rating.RateArticle("Sucks", "News", 1);
            rating.RateArticle("Perfect", "News2", 10);
            rating.RateArticle("Sucks", "News2", 1);

            Assert.AreEqual(2, rating.GetArticleReviews("News").Count);
        }

        [TestMethod]
        public void FindNoArticle()
        {
            rating.RateArticle("Perfect", "News", 10);
            rating.RateArticle("Sucks", "News", 1);
            rating.RateArticle("Perfect", "News2", 10);
            rating.RateArticle("Sucks", "News2", 1);

            Assert.AreEqual(0, rating.GetArticleReviews("Nope").Count);
        }

        [TestMethod]
        public void AverageGrade()
        {
            rating.RateArticle("Perfect", "News", 9);
            rating.RateArticle("Sucks", "News", 1);

            Assert.AreEqual(5, rating.GetGrades("News"));
        }

        [TestMethod]
        public void AverageGradeBig()
        {
            rating.RateArticle("Sucks", "News", 1);
            rating.RateArticle("No", "News", 2);
            rating.RateArticle("Good be better", "News", 3);
            rating.RateArticle("Mwah", "News", 4);
            rating.RateArticle("Potential is there", "News", 5);
            rating.RateArticle("Fine for a quick read", "News", 6);
            rating.RateArticle("Good info, bad writing tho", "News", 7);
            rating.RateArticle("Good info, bad writing tho", "News", 8);
            rating.RateArticle("Good info, bad writing tho", "News", 9);
           

            Assert.AreEqual(5, rating.GetGrades("News"));
        }
    }
}