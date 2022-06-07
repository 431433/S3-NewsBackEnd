using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Rating
    {
        public string Comment { get; set; } 
        public string Title { get; set; }
        public int Grade { get; set; }

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

        public List<Rating> GetArticleReviews(string title)
        {
            List<Rating> articleReviews = new();
            using MySqlConnection con = new(connectionString);
            con.Open();

            MySqlCommand cmd = new($" SELECT `Comment` FROM `reviews` WHERE `Title` = ?title", con);
            cmd.Parameters.AddWithValue("?title", title);

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Rating rating = new();
                rating.Comment = reader["Comment"].ToString();
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
                articleGrade = int.Parse(reader["Comment"].ToString());
                grades.Add(articleGrade);
            }
            reader.Close();

            return CalculateAverage(grades);
        }

        public int CalculateAverage(List<int> grades)
        {
            //Get grades van database
            return (int)Queryable.Average(grades.AsQueryable());
        }
    }
}
