using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.Abstractions.Services;
using MeowieAPI.Application.Repositories.MovieListRepository;

namespace MeowieAPI.Application.Features.Commands.MovieListCommands.CreateMovieList
{
    public class CreateMovieListCommandHandler : IRequestHandler<CreateMovieListCommandRequest, CreateMovieListCommandResponse>
    {
        readonly IMovieListWriteRepository _movieListWriteRepository;
        readonly IUserService _userService;

        public CreateMovieListCommandHandler(IMovieListWriteRepository movieListWriteRepository, IUserService userService)
        {
            _movieListWriteRepository = movieListWriteRepository;
            _userService = userService;
        }

        public async Task<CreateMovieListCommandResponse> Handle(CreateMovieListCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByUsername(request.Username);
            if (user == null) return new() { Success = false, Message = "User not found" };
            var result = await _movieListWriteRepository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                User = user
            });
            if(result == true)
            {
                await _movieListWriteRepository.SaveAsync();
                return new() { Success = true, Message = "Successfully created movie list" };
            }
            return new() { Success = false, Message = "Error when creating movie list" };
        }
    }
}
