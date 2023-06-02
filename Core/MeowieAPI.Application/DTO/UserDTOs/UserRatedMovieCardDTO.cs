using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowieAPI.Application.DTO.UserDTOs
{
    public class UserRatedMovieCardDTO
    {
        public string RatingId { get; set; }
        public string Username { get; set; }
        public string? ProfileImage { get; set; }
        public string MovieName { get; set; }
        public string MovieId { get; set; }
        public string? MovieImage { get; set; }
        public string Comment { get; set; }
        public float Rating { get; set; }
        public float UserRating { get; set; }
        public float ImdbRating { get; set; }
    }
}
