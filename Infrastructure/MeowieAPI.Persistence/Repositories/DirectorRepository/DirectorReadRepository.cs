﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.Repositories.DirectorRepository;
using MeowieAPI.Domain.Entities;
using MeowieAPI.Persistence.Contexts;

namespace MeowieAPI.Persistence.Repositories.DirectorRepository
{
    public class DirectorReadRepository : ReadRepository<Director>, IDirectorReadRepository
    {
        public DirectorReadRepository(MeowieAPIDbContext context) : base(context)
        {
        }
    }
}
