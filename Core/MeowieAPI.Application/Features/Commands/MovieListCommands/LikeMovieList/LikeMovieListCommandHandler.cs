using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.Abstractions.Services;
using MeowieAPI.Application.Repositories.MovieListRepository;

namespace MeowieAPI.Application.Features.Commands.MovieListCommands.LikeMovieList
{
    public class LikeMovieListCommandHandler : IRequestHandler<LikeMovieListCommandRequest, LikeMovieListCommandResponse>
    {
        readonly IUserService _userService;
        readonly IMovieListReadRepository _movieListReadRepository;
        readonly IMovieListWriteRepository _movieListWriteRepository;

        public LikeMovieListCommandHandler(IUserService userService, IMovieListReadRepository movieListReadRepository, IMovieListWriteRepository movieListWriteRepository)
        {
            _userService = userService;
            _movieListReadRepository = movieListReadRepository;
            _movieListWriteRepository = movieListWriteRepository;
        }

        public async Task<LikeMovieListCommandResponse> Handle(LikeMovieListCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Username == null) return new() { Success = false};
            var user = await _userService.GetUserByUsername(request.Username);
            if (user == null) return new() { Success = false};

            if (request.MovieListId == null) return new() { Success = false };
            var movieList = await _movieListReadRepository.GetByIdAsync(request.MovieListId);
            if (movieList == null) return new() { Success = false };

            var isLiked = movieList.Likes.FirstOrDefault(likes => likes.UserId == user.Id);

            if(isLiked != null)
            {
                movieList.Likes.Remove(isLiked);
                await _movieListWriteRepository.SaveAsync();
                return new() { Success = true, IsLiked = false };
            }
            else
            {
                movieList.Likes.Add(new()
                {
                    MovieList = movieList,
                    MovieListId = movieList.Id,
                    User = user,
                    UserId = user.Id
                });
                await _movieListWriteRepository.SaveAsync();
                return new() { Success = true, IsLiked = true };
            }



        }
    }
}
