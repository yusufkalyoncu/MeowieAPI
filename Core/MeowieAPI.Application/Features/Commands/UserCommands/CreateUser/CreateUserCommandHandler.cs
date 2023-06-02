using MediatR;
using MeowieAPI.Application.Abstractions.Services;
using MeowieAPI.Application.DTO.UserDTOs;
using MeowieAPI.Application.Exceptions;
using MeowieAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MeowieAPI.Application.Features.Commands.UserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponseDTO response = await _userService.CreateAsync(new()
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                Username = request.Username,
                Biography = "Hey welcome to my profile. You can look my lists and comments. You can follow me if you want."
            });

            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded,
            };
        }
    }
}
