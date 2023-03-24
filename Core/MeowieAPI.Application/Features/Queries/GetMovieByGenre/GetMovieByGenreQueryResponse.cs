using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.DTO;

namespace MeowieAPI.Application.Features.Queries.GetMovieByGenre
{
    public class GetMovieByGenreQueryResponse
    {
        public List<MovieDTO> Movies { get; set; }
    }
}
