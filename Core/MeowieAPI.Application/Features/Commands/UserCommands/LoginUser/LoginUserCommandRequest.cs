﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeowieAPI.Application.Features.Commands.UserCommands.LoginUser
{
    public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
