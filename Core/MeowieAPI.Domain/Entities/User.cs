using Microsoft.AspNetCore.Identity;
using MeowieAPI.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace MeowieAPI.Domain.Entities
{
    public class User :  IdentityUser<string>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        [Required]
        public override string Email { get => base.Email; set => base.Email = value; }
        public string? ProfileImage { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<User> Follows { get; set; }
        public virtual ICollection<UserLikesMovieList> LikedMovieLists { get; set; }
        public virtual ICollection<MovieList> MovieLists { get; set; }

    }
}
