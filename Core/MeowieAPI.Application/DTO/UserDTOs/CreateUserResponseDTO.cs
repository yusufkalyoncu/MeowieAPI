﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowieAPI.Application.DTO.UserDTOs
{
    public class CreateUserResponseDTO
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
