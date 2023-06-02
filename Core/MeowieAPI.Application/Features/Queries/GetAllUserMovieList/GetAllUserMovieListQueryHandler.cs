using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.Abstractions.Services;
using MeowieAPI.Application.DTO.MovieListDTOs;
using MeowieAPI.Domain.Entities;

namespace MeowieAPI.Application.Features.Queries.GetAllUserMovieList
{
    public class GetAllUserMovieListQueryHandler : IRequestHandler<GetAllUserMovieListQueryRequest, GetAllUserMovieListQueryResponse>
    {
        readonly IUserService _userService;

        public GetAllUserMovieListQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetAllUserMovieListQueryResponse> Handle(GetAllUserMovieListQueryRequest request, CancellationToken cancellationToken)
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

            if(loggedUser == null)
            {
                MovieLists = listOwner.MovieLists.Select(ml => new MovieListCardDTO()
                {
                    Id = ml.Id,
                    LikesCount = ml.Likes.Count(),
                    MovieCount = ml.Movies.Count(),
                    Title = ml.Title,
                    IsLiked = false
                }).ToList();
            }
            else
            {
                MovieLists = listOwner.MovieLists.Select(ml =>
                {
                    var isLiked = ml.Likes.FirstOrDefault(likes => likes.UserId == loggedUser.Id);

                    return new MovieListCardDTO()
                    {
                        Id = ml.Id,
                        LikesCount = ml.Likes.Count(),
                        MovieCount = ml.Movies.Count(),
                        Title = ml.Title,
                        IsLiked = isLiked != null ? true : false
                    };
                }).ToList();
            }
            return new() { MovieLists = MovieLists };
        }
    }
}
