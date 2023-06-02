using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.DTO;

namespace MeowieAPI.Application.Features.Queries.SearchMovie
{
    public class SearchMovieQueryResponse
    {
        public List<MovieDTO> Movies { get; set; }
        public int TotalMovieCount { get; set; }
    }
}
