using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using MeowieAPI.Application.Abstractions.ImdbService;
using MeowieAPI.Application.Models;
using MeowieAPI.Application.Repositories.ActorRepository;
using MeowieAPI.Application.Repositories.DirectorRepository;
using MeowieAPI.Application.Repositories.MovieRepository;

namespace MeowieAPI.Persistence.Services
{
    public class ImdbService : IImdbService
    {
        readonly IActorWriteRepository _actorWriteRepository;
        readonly IDirectorWriteRepository _directorWriteRepository;
        readonly IMovieWriteRepository _movieWriteRepository;

        readonly IActorReadRepository _actorReadRepository;
        readonly IDirectorReadRepository _directorReadRepository;
        readonly IMovieReadRepository _movieReadRepository;

        public ImdbService(IActorWriteRepository actorWriteRepository, IDirectorWriteRepository directorWriteRepository, IMovieWriteRepository movieWriteRepository, IActorReadRepository actorReadRepository, IDirectorReadRepository directorReadRepository, IMovieReadRepository movieReadRepository)
        {
            _actorWriteRepository = actorWriteRepository;
            _directorWriteRepository = directorWriteRepository;
            _movieWriteRepository = movieWriteRepository;
            _actorReadRepository = actorReadRepository;
            _directorReadRepository = directorReadRepository;
            _movieReadRepository = movieReadRepository;
        }

        public List<Domain.Entities.Actor> FindActor(List<Application.Models.Actor> actors, List<Domain.Entities.Actor> list)
        {
            List<Domain.Entities.Actor> findActors = new List<Domain.Entities.Actor>();

            foreach (Domain.Entities.Actor data in list)
            {
                foreach (Actor actor in actors)
                {
                    if (actor.url == data.ImageURL)
                    {
                        findActors.Add(data);
                    }
                }
            }
            return findActors;
        }

        public Domain.Entities.Director FindDirector(Application.Models.Director director, List<Domain.Entities.Director> list)
        {
            foreach (Domain.Entities.Director data in list)
            {
                if (data.ImageURL == director.url)
                {
                    return data;
                }
            }
            return new();
        }

        public bool isHaveActor(Application.Models.Actor actor, List<Application.Models.Actor> list)
        {
            foreach (Actor data in list)
            {
                if (data.url == actor.url) return true;
            }
            return false;
        }

        public bool isHaveDirector(Application.Models.Director director, List<Application.Models.Director> list)
        {
            foreach (Director data in list)
            {
                if (data.url == director.url) return true;
            }
            return false;
        }

        public async Task<bool> PushToDbAsync()
        {
            List<Actor> actorsList = new List<Actor>();
            List<Director> directorsList = new List<Director>();
            List<Root>? Roots = JsonSerializer.Deserialize<List<Root>>(ImdbAPIModel.jsonText);

            foreach (Root root in Roots)
            {
                foreach (Actor actor in root.actor)
                {
                    if (!isHaveActor(actor, actorsList))
                    {
                        await _actorWriteRepository.AddAsync(new()
                        {
                            Name = actor.name,
                            ImageURL = actor.url
                        });
                        actorsList.Add(actor);
                        await _actorWriteRepository.SaveAsync();
                    }

                }

                foreach (Director director in root.director)
                {
                    if (!isHaveDirector(director, directorsList))
                    {
                        await _directorWriteRepository.AddAsync(new()
                        {
                            Name = director.name,
                            ImageURL = director.url
                        });
                        directorsList.Add(director);
                        await _directorWriteRepository.SaveAsync();
                    }
                }

                List<Domain.Entities.Actor> actorsListDB = _actorReadRepository.GetAll().ToList();
                List<Domain.Entities.Director> directorsListDB = _directorReadRepository.GetAll().ToList();

                foreach (Root root2 in Roots)
                {
                    Domain.Entities.Director currentDirector = FindDirector(root2.director[0], directorsListDB);
                    await _movieWriteRepository.AddAsync(new()
                    {
                        Name = root2.name,
                        Genres = root2.genre,
                        ReleaseDate = DateTime.Parse(root2.datePublished).ToUniversalTime(),
                        Description = root2.description,
                        UserRating = 0,
                        ImdbRating = (float)root2.aggregateRating.ratingValue,
                        Duration = XmlConvert.ToTimeSpan(root2.duration),
                        ImageURL = root2.image,
                        Director = currentDirector,
                        DirectorId = currentDirector.Id,
                        Actors = FindActor(root2.actor, actorsListDB),

                    });
                    await _movieWriteRepository.SaveAsync();
                }

            }
            return true;
        }
    }
}
