using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeowieAPI.Application.Features.Commands.MovieListCommands.LikeMovieList
{
    public class LikeMovieListCommandRequest : IRequest<LikeMovieListCommandResponse>
    {
        public string MovieListId { get; set; }
        public string Username { get; set; }
    }
}
