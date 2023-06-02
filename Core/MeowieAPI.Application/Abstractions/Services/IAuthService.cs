using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.DTO;

namespace MeowieAPI.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<TokenDTO> GoogleLoginAsync(string idToken, int lifeTimeSecond);
        Task<TokenDTO> LoginAsync(string usernameOrEmail, string password, int lifeTimeSecond);
        Task<TokenDTO> RefreshTokenLoginAsync(string refreshToken, int lifeTimeSecond);
    }
}
