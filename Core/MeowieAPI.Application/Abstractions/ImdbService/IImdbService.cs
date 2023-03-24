using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.Models;

namespace MeowieAPI.Application.Abstractions.ImdbService
{
    public interface IImdbService
    {
        bool isHaveDirector(Director director, List<Director> list);
        bool isHaveActor(Actor actor, List<Actor> list);
        List<Domain.Entities.Actor> FindActor(List<Actor> actors, List<Domain.Entities.Actor> list);
        Domain.Entities.Director FindDirector(Director director, List<Domain.Entities.Director> list);
        public Task<bool> PushToDbAsync();
    }
}
