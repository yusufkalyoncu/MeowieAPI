using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.DTO;

namespace MeowieAPI.Application.Features.Queries.GetRandomMovie
{
    public class GetRandomMovieQueryResponse
    {
        public List<MovieDTO> Movies { get; set; }
    }
}
