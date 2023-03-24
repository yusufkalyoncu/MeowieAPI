using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.DTO;

namespace MeowieAPI.Application.Features.Queries.GetSingleMovie
{
    public class GetSingleMovieQueryResponse
    {
        public MovieDetailsDTO Movie { get; set; }
    }
}
