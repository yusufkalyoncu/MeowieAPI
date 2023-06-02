using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeowieAPI.Application.Features.Commands.MovieListCommands.AddMovieToList
{
    public class AddMovieToListCommandRequest : IRequest<AddMovieToListCommandResponse>
    {
        public string MovieId { get; set; }
        public string MovieListId { get; set; }
    }
}
