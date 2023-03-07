using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Domain.Entities.Common;

namespace MeowieAPI.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public List<string> Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public float UserRating { get; set; }
        public float ImdbRating { get; set; }
        public TimeSpan Duration { get; set; }
        public string ImageURL { get; set; }
        public Director Director { get; set; }
        public Guid DirectorId { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<MovieList> ContainsMovieLists { get; set; }
    }
}
