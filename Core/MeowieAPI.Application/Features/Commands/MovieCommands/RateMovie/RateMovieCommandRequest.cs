using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeowieAPI.Application.Features.Commands.MovieCommands.RateMovie
{
    public class RateMovieCommandRequest : IRequest<RateMovieCommandResponse>
    {
        public string Comment { get; set; }
        public float Rate { get; set; }
        public Guid MovieId { get; set; }
        public string Username { get; set; }
    }
}
