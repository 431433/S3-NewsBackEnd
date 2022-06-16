using MySql.Data.MySqlClient;
using BackEndContract;
using BackEndDTO;

namespace BackEndDAL
{
    public class RatingDAL : IRatingDAL
    {
        private readonly string connectionString = "Server=studmysql01.fhict.local;Uid=dbi431433;Database=dbi431433;Pwd=Fontys1234;SSL Mode=None";
        public void RateArticle(string comment, string title, int grade)
        {
            using MySqlConnection con = new(connectionString);
            con.Open();

            MySqlCommand cmd = new($"INSERT INTO `reviews`(`Title`, `Grade`, `Comment`) VALUES (?title, ?grade, ?comment)", con);
            cmd.Parameters.AddWithValue("?title", title);
            cmd.Parameters.AddWithValue("?grade", grade);
            cmd.Parameters.AddWithValue("?comment", comment);

            MySqlDataReader reader = cmd.ExecuteReader();
        }

        public List<RatingDTO> GetArticleReviews(string title)
        {
            List<RatingDTO> articleReviews = new();
            using MySqlConnection con = new(connectionString);
            con.Open();

            MySqlCommand cmd = new($" SELECT `Comment`, `Grade` FROM `reviews` WHERE `Title` = ?title", con);
            cmd.Parameters.AddWithValue("?title", title);

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                RatingDTO rating = new();
                rating.Comment = reader["Comment"].ToString();
                rating.Grade = int.Parse(reader["Grade"].ToString());
                articleReviews.Add(rating);
            }
            reader.Close();

            return articleReviews;
        }


        public int GetGrades(string title)
        {
            List<int> grades = new();
            using MySqlConnection con = new(connectionString);
            con.Open();

            MySqlCommand cmd = new($" SELECT `Grade` FROM `reviews` WHERE `Title` = ?title", con);
            cmd.Parameters.AddWithValue("?title", title);

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int articleGrade;
                articleGrade = int.Parse(reader["Grade"].ToString());
                grades.Add(articleGrade);
            }
            reader.Close();

            int grade = (int)Queryable.Average(grades.AsQueryable());
            return grade;
        }
    }
}
