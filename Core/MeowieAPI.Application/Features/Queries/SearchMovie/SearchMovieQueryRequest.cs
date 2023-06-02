using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeowieAPI.Application.Features.Queries.SearchMovie
{
    public class SearchMovieQueryRequest : IRequest<SearchMovieQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Count { get; set; } = 5;
        public bool Shuffle { get; set; } = false;
        public string SearchKeyword { get; set; }
    }
}
