using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeowieAPI.Application.Features.Queries.GetRandomMovie
{
    public class GetRandomMovieQueryRequest : IRequest<GetRandomMovieQueryResponse>
    {
        public int Count { get; set; }
    }
}
