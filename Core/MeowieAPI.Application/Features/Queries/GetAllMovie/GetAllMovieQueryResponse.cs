using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.DTO;

namespace MeowieAPI.Application.Features.Queries.GetAllMovie
{
    public class GetAllMovieQueryResponse
    {
        public List<MovieDTO> Movies { get; set; }
        public int TotalMovieCount { get; set; }
    }
}
