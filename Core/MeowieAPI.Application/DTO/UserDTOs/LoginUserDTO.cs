using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowieAPI.Application.DTO.UserDTOs
{
    public class LoginUserDTO
    {
        public TokenDTO? Token { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
