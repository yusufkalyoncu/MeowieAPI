using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.RequestParameters;

namespace MeowieAPI.Application.Features.Queries.GetAllMovie
{
    public class GetAllMovieQueryRequest : IRequest<GetAllMovieQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Count { get; set; } = 5;
        public bool Shuffle { get; set; } = false;
    }
}
