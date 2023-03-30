using Microsoft.AspNetCore.Identity;
using MeowieAPI.Domain.Entities.Common;

namespace MeowieAPI.Domain.Entities
{
    public class User :  IdentityUser<string>
    {
        public string Name { get; set; }
        public string? ProfileImage { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<User> Follows { get; set; }
        public virtual ICollection<UserLikesMovieList> LikedMovieLists { get; set; }
        public virtual ICollection<MovieList> MovieLists { get; set; }

    }
}
