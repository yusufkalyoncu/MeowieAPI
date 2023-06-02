using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.DTO.MovieDTOs;
using MeowieAPI.Application.DTO.MovieListDTOs;
using MeowieAPI.Application.Repositories.MovieListRepository;
using MeowieAPI.Domain.Entities;

namespace MeowieAPI.Application.Features.Queries.GetSingleMovieList
{
    public class GetSingleMovieListQueryHandler : IRequestHandler<GetSingleMovieListQueryRequest, GetSingleMovieListQueryResponse>
    {
        readonly IMovieListReadRepository _movieListReadRepository;

        public GetSingleMovieListQueryHandler(IMovieListReadRepository movieListReadRepository)
        {
            _movieListReadRepository = movieListReadRepository;
        }

        public async Task<GetSingleMovieListQueryResponse> Handle(GetSingleMovieListQueryRequest request, CancellationToken cancellationToken)
        {
            var movieList = await _movieListReadRepository.GetByIdAsync(request.Id);
            if (movieList == null) return null;
            return new()
            {
                User = new()
                {
                    Name = movieList.User.Name,
                    Username = movieList.User.UserName,
                    ProfileImage = movieList.User.ProfileImage,
                },
                Title = movieList.Title,
                Movies = movieList.Movies.Select(movie => new MovieListMovieDTO()
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    ImageURL = movie.ImageURL,
                    ImdbRating = movie.ImdbRating,
                    UserRating = movie.UserRating
                }).ToList(),

            };

        }
    }
}
