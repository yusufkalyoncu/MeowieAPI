using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.DTO;
using MeowieAPI.Application.Repositories.MovieRepository;
using MeowieAPI.Domain.Entities;

namespace MeowieAPI.Application.Features.Queries.GetSingleMovie
{
    public class GetSingleMovieQueryHandler : IRequestHandler<GetSingleMovieQueryRequest, GetSingleMovieQueryResponse>
    {
        readonly IMovieReadRepository _movieReadRepository;

        public GetSingleMovieQueryHandler(IMovieReadRepository movieReadRepository)
        {
            _movieReadRepository = movieReadRepository;
        }

        public async Task<GetSingleMovieQueryResponse> Handle(GetSingleMovieQueryRequest request, CancellationToken cancellationToken)
        {
            Movie movie = await _movieReadRepository.GetByIdAsync(request.Id);
            MovieDetailsDTO response = new()
            {
                Id = movie.Id,
                Name = movie.Name,
                Genres = movie.Genres,
                ReleaseDate = movie.ReleaseDate,
                Description = movie.Description,
                UserRating = movie.UserRating,
                ImdbRating = movie.ImdbRating,
                Duration = movie.Duration,
                ImageURL = movie.ImageURL,
                BannerURL = movie.BannerURL,
                Director = new() { Id = movie.Director.Id, Name = movie.Director.Name, ImageURL = movie.Director.ImageURL },
                DirectorId = movie.DirectorId,
                Actors = movie.Actors.Select(a => new ActorDTO() { Id = a.Id, Name = a.Name, ImageURL = a.ImageURL }).ToList(),
                Comments = movie.Comments.Select(c => new CommentDTO() { Content = c.Content, CreatedDate = c.CreatedDate, Username = c.User.UserName, UserRating = c.UserRating }).ToList(),
            };
            return new GetSingleMovieQueryResponse() { Movie = response };
        }
    }
}
