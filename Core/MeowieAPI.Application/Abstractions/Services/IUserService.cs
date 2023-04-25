using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.DTO.UserDTOs;
using MeowieAPI.Domain.Entities;

namespace MeowieAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO model);
        Task UpdateRefreshToken(string refreshToken, User user, DateTime accessTokenDate, int addOnAccessTokenDate);
        Task<User> GetUserByUsername(string username);
    }
}
