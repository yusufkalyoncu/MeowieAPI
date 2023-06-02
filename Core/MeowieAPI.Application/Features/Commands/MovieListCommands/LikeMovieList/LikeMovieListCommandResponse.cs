using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowieAPI.Application.Features.Commands.MovieListCommands.LikeMovieList
{
    public class LikeMovieListCommandResponse
    {
        public bool Success { get; set; }
        public bool IsLiked { get; set; }
    }
}
