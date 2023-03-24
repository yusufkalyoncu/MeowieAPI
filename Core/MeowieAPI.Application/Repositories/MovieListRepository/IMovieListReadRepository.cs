using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Domain.Entities;

namespace MeowieAPI.Application.Repositories.MovieListRepository
{
    public interface IMovieListReadRepository : IReadRepository<MovieList>
    {
    }
}
