using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.Abstractions.Services;
using MeowieAPI.Application.DTO.MovieListDTOs;
using MeowieAPI.Domain.Entities;

namespace MeowieAPI.Application.Features.Queries.GetAllUserLikedMovieList
{
    public class GetAllUserLikedMovieListQueryHandler : IRequestHandler<GetAllUserLikedMovieListQueryRequest, GetAllUserLikedMovieListQueryResponse>
    {
        readonly IUserService _userService;

        public GetAllUserLikedMovieListQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetAllUserLikedMovieListQueryResponse> Handle(GetAllUserLikedMovieListQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.ListOwnerUsername == null) return new() { MovieLists = null };
            var listOwner = await _userService.GetUserByUsername(request.ListOwnerUsername);
            if (listOwner == null) return new() { MovieLists = null };

            User? loggedUser = null;
            if (request.LoggedUsername != null)
            {
                loggedUser = await _userService.GetUserByUsername(request.LoggedUsername);
            }

            List<MovieListCardDTO> MovieLists;

            if (loggedUser == null)
            {
                MovieLists = listOwner.LikedMovieLists.Select(ml => new MovieListCardDTO()
                {
                    Id = ml.MovieList.Id,
                    LikesCount = ml.MovieList.Likes.Count(),
                    MovieCount = ml.MovieList.Movies.Count(),
                    Title = ml.MovieList.Title,
                    IsLiked = false
                }).ToList();
            }
            else
            {
                MovieLists = listOwner.LikedMovieLists.Select(ml =>
                {
                    var isLiked = ml.MovieList.Likes.FirstOrDefault(likes => likes.UserId == loggedUser.Id);

                    return new MovieListCardDTO()
                    {
                        Id = ml.MovieList.Id,
                        LikesCount = ml.MovieList.Likes.Count(),
                        MovieCount = ml.MovieList.Movies.Count(),
                        Title = ml.MovieList.Title,
                        IsLiked = isLiked != null ? true : false
                    };
                }).ToList();
            }
            return new() { MovieLists = MovieLists };
        }
    }
}
