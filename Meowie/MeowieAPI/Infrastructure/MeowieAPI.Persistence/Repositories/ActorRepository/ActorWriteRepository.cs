using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.Repositories.ActorRepository;
using MeowieAPI.Domain.Entities;
using MeowieAPI.Persistence.Contexts;

namespace MeowieAPI.Persistence.Repositories.ActorRepository
{
    public class ActorWriteRepository : WriteRepository<Actor>, IActorWriteRepository
    {
        public ActorWriteRepository(MeowieAPIDbContext context) : base(context)
        {
        }
    }
}
