﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.Repositories.MovieListRepository;
using MeowieAPI.Domain.Entities;
using MeowieAPI.Persistence.Contexts;

namespace MeowieAPI.Persistence.Repositories.MovieListRepository
{
    public class MovieListWriteRepository : WriteRepository<MovieList>, IMovieListWriteRepository
    {
        public MovieListWriteRepository(MeowieAPIDbContext context) : base(context)
        {
        }
    }
}
