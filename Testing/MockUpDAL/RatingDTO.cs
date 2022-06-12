using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.MockUpDAL
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
    }
}
