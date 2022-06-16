namespace BackEndDTO
{
    public class RatingDTO
    {
        public string Comment { get; set; }
        public string Title { get; set; }
        public int Grade { get; set; }

        public RatingDTO(string comment, string title, int grade)
        {
            Comment = comment;
            Title = title;
            Grade = grade;
        }

        public RatingDTO()
        {
        }

        public RatingDTO(RatingDTO rating)
        {
            Comment =rating.Comment;
            Title = rating.Title;
            Grade = rating.Grade;
        }
    }
}