using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.DTO.UserDTOs;

namespace MeowieAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponseDTO> CreateAsync(CreateUserDTO model);
    }
}
