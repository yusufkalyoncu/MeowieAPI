using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowieAPI.Application.DTO.MovieListDTOs
{
    public class MovieListCardDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int LikesCount { get; set; }
        public int MovieCount { get; set; }
        public bool IsLiked { get; set; } = false;
    }
}
