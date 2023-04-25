using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.Abstractions.Services;
using MeowieAPI.Application.DTO.UserDTOs;
using MeowieAPI.Application.Exceptions;
using MeowieAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MeowieAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                UserName = model.Username,
                Email = model.Email,
                ProfileImage = "test"
            }, model.Password);
            if (result.Succeeded)
            {
                return new() { Succeeded = true, Message = "User created successfully" };
            }
            else
            {
                return new() { Succeeded = false, Message = result.Errors.First().Description };
            }
        }

        public async Task UpdateRefreshToken(string refreshToken, User user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else throw new UserNotFoundException();
        }


        public async Task<User> GetUserByUsername(string username)
        {
            User? user = await _userManager.FindByNameAsync(username);
            if (user != null) return user;
            else throw new UserNotFoundException();
        }
    }
}
