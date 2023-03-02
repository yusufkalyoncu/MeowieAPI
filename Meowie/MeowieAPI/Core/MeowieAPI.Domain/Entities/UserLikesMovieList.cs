using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowieAPI.Domain.Entities
{
    public class UserLikesMovieList
    {
        public Guid UserId { get; set; }
        public Guid MovieListId { get; set; }
        public User User { get; set; }
        public MovieList MovieList { get; set; }
    }
}
