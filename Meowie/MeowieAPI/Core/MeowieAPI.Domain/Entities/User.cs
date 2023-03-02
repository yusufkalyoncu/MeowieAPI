using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Domain.Entities.Common;

namespace MeowieAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ProfileImage { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<User> Follows { get; set; }
        public ICollection<UserLikesMovieList> LikedMovieLists { get; set; }
        public ICollection<MovieList> MovieLists { get; set; }

    }
}
