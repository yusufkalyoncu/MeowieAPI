using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeowieAPI.Application.Features.Queries.GetMovieByGenre
{
    public class GetMovieByGenreQueryRequest : IRequest<GetMovieByGenreQueryResponse>
    {
        public List<string> Genres { get; set; }
        public int Count { get; set; }
    }
}
