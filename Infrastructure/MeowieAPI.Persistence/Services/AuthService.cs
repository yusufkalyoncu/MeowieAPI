using Microsoft.Extensions.Configuration;
using Google.Apis.Auth;
using MeowieAPI.Application.Abstractions.Services;
using MeowieAPI.Application.Abstractions.Token;
using MeowieAPI.Application.DTO;
using MeowieAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using MediatR;
using MeowieAPI.Application.Exceptions;

namespace MeowieAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IConfiguration _configuration;

        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ITokenHandler tokenHandler,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
        }

        public async Task<TokenDTO> GoogleLoginAsync(string idToken, int lifeTimeSecond)
        {

            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string>
                {
                    _configuration["LoginSettings:Google:Client_ID"]
                }
            };
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");
            User? user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            bool result = user != null;

            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = payload.Email,
                        UserName = payload.Email,
                        Name = payload.Name,
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }
            if (result)
            {
                await _userManager.AddLoginAsync(user, info);
            }
            else
            {
                throw new Exception("Invalid external authentication");
            }
            TokenDTO token = _tokenHandler.CreateAccessToken(lifeTimeSecond);

            return token;
        }

        public async Task<TokenDTO> LoginAsync(string usernameOrEmail, string password, int lifeTimeSecond)
        {
            User? user = await _userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(usernameOrEmail);

            if (user == null)
                throw new UserNotFoundException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {
                TokenDTO token = _tokenHandler.CreateAccessToken(lifeTimeSecond);
                return token;
            }
            else
            {
                throw new AuthenticationErrorException();
            }
        }
    }
}
