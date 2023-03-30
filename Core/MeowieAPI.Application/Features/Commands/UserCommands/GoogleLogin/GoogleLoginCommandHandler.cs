using MediatR;
using MeowieAPI.Application.Abstractions.Services;
using MeowieAPI.Application.DTO;

namespace MeowieAPI.Application.Features.Commands.UserCommands.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        readonly IAuthService _authService;

        public GoogleLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            TokenDTO token = await _authService.GoogleLoginAsync(request.IdToken, 30);
            return new()
            {
                Token = token,
            };
        }
    }
}
