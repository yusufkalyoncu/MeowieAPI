using MediatR;
using MeowieAPI.Application.Exceptions;
using MeowieAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MeowieAPI.Application.Features.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<User> _userManager;

        public CreateUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                UserName = request.Username,
                Email = request.Email,
            },request.Password);
            if(result.Succeeded)
            {
                return new() { Succeeded = true, Message = "User created successfully" };
            }
            else
            {
                return new() { Succeeded = false, Message = result.Errors.First().Description };
            }
        }
    }
}
