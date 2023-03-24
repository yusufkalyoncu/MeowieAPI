using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeowieAPI.Application.Features.Queries.GetSingleMovie
{
    public class GetSingleMovieQueryRequest : IRequest<GetSingleMovieQueryResponse>
    {
        public string Id { get; set; }
    }
}
