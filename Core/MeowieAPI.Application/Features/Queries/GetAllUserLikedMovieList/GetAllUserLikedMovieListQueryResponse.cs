using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.DTO.MovieListDTOs;

namespace MeowieAPI.Application.Features.Queries.GetAllUserLikedMovieList
{
    public class GetAllUserLikedMovieListQueryResponse
    {
        public ICollection<MovieListCardDTO>? MovieLists { get; set; }
    }
}
