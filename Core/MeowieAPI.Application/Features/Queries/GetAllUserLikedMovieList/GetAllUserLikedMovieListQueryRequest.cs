using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeowieAPI.Application.Features.Queries.GetAllUserLikedMovieList
{
    public class GetAllUserLikedMovieListQueryRequest : IRequest<GetAllUserLikedMovieListQueryResponse>
    {
        public string? ListOwnerUsername { get; set; }
        public string? LoggedUsername { get; set; }
    }
}
