using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Domain.Entities.Common;

namespace MeowieAPI.Domain.Entities
{
    public class MovieList : BaseEntity
    {
        public string Title { get; set; }
        public virtual User User { get; set; }
        //public Guid UserId { get; set; }
        public virtual ICollection<UserLikesMovieList> Likes { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
