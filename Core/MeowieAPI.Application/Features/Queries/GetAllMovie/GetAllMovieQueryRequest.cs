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
        public Pagination Pagination { get; set; } = new() { Page = 0, Size = 20 };
    }
}
