using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.Repositories.MovieRepository;
using MeowieAPI.Domain.Entities;
using MeowieAPI.Persistence.Contexts;

namespace MeowieAPI.Persistence.Repositories.MovieRepository
{
    public class MovieReadRepository : ReadRepository<Movie>, IMovieReadRepository
    {
        public MovieReadRepository(MeowieAPIDbContext context) : base(context)
        {
        }
    }
}
