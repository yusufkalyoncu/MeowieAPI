using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.DTO;
using MeowieAPI.Application.Repositories.MovieRepository;

namespace MeowieAPI.Application.Features.Queries.GetAllMovie
{
    public class GetAllMovieQueryHandler : IRequestHandler<GetAllMovieQueryRequest, GetAllMovieQueryResponse>
    {
        readonly IMovieReadRepository _movieReadRepository;

        public GetAllMovieQueryHandler(IMovieReadRepository movieReadRepository)
        {
            _movieReadRepository = movieReadRepository;
        }

        public async Task<GetAllMovieQueryResponse> Handle(GetAllMovieQueryRequest request, CancellationToken cancellationToken)
        {
            List<MovieDTO> movies = _movieReadRepository.GetAll().Skip(request.Page * request.Count).Take(request.Count).Select(
                m => new MovieDTO
                {
                    Duration = m.Duration,
                    Genres = m.Genres,
                    Description = m.Description,
                    Id = m.Id,
                    ImageURL = m.ImageURL,
                    BannerURL = m.BannerURL,
                    ImdbRating = m.ImdbRating,
                    UserRating = m.UserRating,
                    Name = m.Name,
                    ReleaseDate = m.ReleaseDate
                }).ToList();

            if (request.Shuffle)
            {
                return new GetAllMovieQueryResponse() { Movies = ShuffleMovies(movies) };
            }

            return new GetAllMovieQueryResponse() { Movies = movies };
        }

        public List<MovieDTO> ShuffleMovies(List<MovieDTO> movies)
        {
            Random rnd = new Random();
            for (int i = 0; i < movies.Count; i++)
            {
                int randomIndex = rnd.Next(movies.Count);
                MovieDTO movie = movies[randomIndex];
                movies[randomIndex] = movies[i];
                movies[i] = movie;
            }
            return movies;
        }
    }
}
