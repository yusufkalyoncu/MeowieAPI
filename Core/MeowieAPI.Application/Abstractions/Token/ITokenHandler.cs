using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.DTO;
using MeowieAPI.Domain.Entities;

namespace MeowieAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        TokenDTO CreateAccessToken(int second, User user);
        string CreateRefreshToken();
    }
}
