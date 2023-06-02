using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowieAPI.Application.DTO.MovieDTOs
{
    public class MovieListMovieDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float UserRating { get; set; }
        public float ImdbRating { get; set; }
        public string ImageURL { get; set; }
    }
}
