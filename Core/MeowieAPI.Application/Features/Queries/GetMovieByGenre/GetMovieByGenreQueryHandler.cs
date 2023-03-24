using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.DTO;
using MeowieAPI.Application.Features.Queries.GetRandomMovie;
using MeowieAPI.Application.Repositories.MovieRepository;
using MeowieAPI.Domain.Entities;

namespace MeowieAPI.Application.Features.Queries.GetMovieByGenre
{
    public class GetMovieByGenreQueryHandler : IRequestHandler<GetMovieByGenreQueryRequest, GetMovieByGenreQueryResponse>
    {
        readonly IMovieReadRepository _movieReadRepository;

        public GetMovieByGenreQueryHandler(IMovieReadRepository movieReadRepository)
        {
            _movieReadRepository = movieReadRepository;
        }

        public async Task<GetMovieByGenreQueryResponse> Handle(GetMovieByGenreQueryRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<Movie, bool>> processingFunc = m => m.Genres.Any(g => request.Genres.Contains(g));

            List<MovieDTO> movies = _movieReadRepository.GetWhere(processingFunc)
                .Select(m => new MovieDTO
            {
                Id = m.Id,
                Duration = m.Duration,
                Genres = m.Genres,
                Description = m.Description,
                ImageURL = m.ImageURL,
                BannerURL = m.BannerURL,
                ImdbRating = m.ImdbRating,
                UserRating = m.UserRating,
                Name = m.Name,
                ReleaseDate = m.ReleaseDate
            }).ToList();
            movies = ShuffleMovies(movies).Take(request.Count).ToList();
            
            return new GetMovieByGenreQueryResponse() { Movies = movies };


        }

        public List<MovieDTO> ShuffleMovies(List<MovieDTO> movies)
        {
            Random rnd = new Random();
            for(int i = 0; i < movies.Count; i++)
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
