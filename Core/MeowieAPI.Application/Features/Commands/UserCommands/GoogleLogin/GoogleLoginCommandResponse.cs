﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.DTO;

namespace MeowieAPI.Application.Features.Commands.UserCommands.GoogleLogin
{
    public class GoogleLoginCommandResponse
    {
        public TokenDTO Token { get; set; }
    }
}