using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.DTO.MovieDTOs;
using MeowieAPI.Application.DTO.MovieListDTOs;
using MeowieAPI.Application.DTO.UserDTOs;

namespace MeowieAPI.Application.Features.Queries.GetSingleMovieList
{
    public class GetSingleMovieListQueryResponse
    {
        public UserMovieListDTO User { get; set; }
        public string Title { get; set; }
        public virtual ICollection<MovieListMovieDTO> Movies { get; set; }

    }
}
