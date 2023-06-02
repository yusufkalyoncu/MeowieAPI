using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeowieAPI.Application.Features.Queries.GetSingleMovieList
{
    public class GetSingleMovieListQueryRequest : IRequest<GetSingleMovieListQueryResponse>
    {
        public string Id { get; set; }
    }
}
