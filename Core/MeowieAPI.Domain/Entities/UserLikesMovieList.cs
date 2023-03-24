using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowieAPI.Domain.Entities
{
    public class UserLikesMovieList
    {
        public string UserId { get; set; }
        public Guid MovieListId { get; set; }
        public virtual User User { get; set; }
        public virtual MovieList MovieList { get; set; }
    }
}
