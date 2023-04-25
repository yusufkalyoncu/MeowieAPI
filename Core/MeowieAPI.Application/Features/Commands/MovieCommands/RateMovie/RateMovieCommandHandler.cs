using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.Abstractions.Services;
using MeowieAPI.Application.Repositories.CommentRepository;
using MeowieAPI.Domain.Entities;

namespace MeowieAPI.Application.Features.Commands.MovieCommands.RateMovie
{
    public class RateMovieCommandHandler : IRequestHandler<RateMovieCommandRequest, RateMovieCommandResponse>
    {
        readonly IUserService _userService;
        readonly ICommentWriteRepository _commentWriteRepository;

        public RateMovieCommandHandler(IUserService userService, ICommentWriteRepository commentWriteRepository)
        {
            _userService = userService;
            _commentWriteRepository = commentWriteRepository;
        }

        public async Task<RateMovieCommandResponse> Handle(RateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            
            User user = await _userService.GetUserByUsername(request.Username);
            if(user == null)
            {
                return new() { Message = "User not found !", Success = false };
            }
            else
            {
                var repositoryResponse = await _commentWriteRepository.AddAsync(new()
                {
                    Id = Guid.NewGuid(),
                    Content = request.Comment,
                    CreatedDate = DateTime.UtcNow,
                    MovieId = request.MovieId,
                    User = user,
                    UserRating = request.Rate,
                });

                if (repositoryResponse)
                {
                    await _commentWriteRepository.SaveAsync();
                    return new()
                    {
                        Message = "Successfuly rated",
                        Success = true
                    };
                }
                else
                {
                    return new()
                    {
                        Message = "Error when save rating",
                        Success = false
                    };
                }
            }

        }
    }
}
