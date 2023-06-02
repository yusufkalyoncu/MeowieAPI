using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeowieAPI.Application.Features.Commands.MovieListCommands.CreateMovieList
{
    public class CreateMovieListCommandRequest : IRequest<CreateMovieListCommandResponse>
    {
        public string Username { get; set; }
        public string Title { get; set; }
    }
}
