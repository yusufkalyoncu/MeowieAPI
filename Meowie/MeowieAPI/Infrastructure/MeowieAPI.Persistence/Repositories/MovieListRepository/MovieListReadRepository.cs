using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.Repositories.MovieListRepository;
using MeowieAPI.Domain.Entities;
using MeowieAPI.Persistence.Contexts;

namespace MeowieAPI.Persistence.Repositories.MovieListRepository
{
    public class MovieListReadRepository : ReadRepository<MovieList>, IMovieListReadRepository
    {
        public MovieListReadRepository(MeowieAPIDbContext context) : base(context)
        {
        }
    }
}
