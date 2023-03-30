using MediatR;
using MeowieAPI.Application.Features.Commands.UserCommands.CreateUser;
using MeowieAPI.Application.Features.Commands.UserCommands.GoogleLogin;
using MeowieAPI.Application.Features.Commands.UserCommands.LoginUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace MeowieAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok();
        }


    }
}
