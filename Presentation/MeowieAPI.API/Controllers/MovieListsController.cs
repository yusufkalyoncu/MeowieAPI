using MediatR;
using MeowieAPI.Application.Features.Commands.MovieListCommands.AddMovieToList;
using MeowieAPI.Application.Features.Commands.MovieListCommands.CreateMovieList;
using MeowieAPI.Application.Features.Commands.MovieListCommands.LikeMovieList;
using MeowieAPI.Application.Features.Queries.GetAllMovie;
using MeowieAPI.Application.Features.Queries.GetAllUserLikedMovieList;
using MeowieAPI.Application.Features.Queries.GetAllUserMovieList;
using MeowieAPI.Application.Features.Queries.GetSingleMovieList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeowieAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieListsController : ControllerBase
    {
        readonly IMediator _mediator;

        public MovieListsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateMovieList(CreateMovieListCommandRequest createMovieListCommandRequest)
        {
            CreateMovieListCommandResponse response = await _mediator.Send(createMovieListCommandRequest);
            if (response.Success == true) return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("user-movielist")]
        public async Task<IActionResult> GetAllUserMovieList([FromQuery] GetAllUserMovieListQueryRequest getAllUserMovieListQueryRequest)
        {
            GetAllUserMovieListQueryResponse response = await _mediator.Send(getAllUserMovieListQueryRequest);
            return Ok(response);
        }
        [HttpGet("user-liked-movielist")]
        public async Task<IActionResult> GetAllUserLikedMovieList([FromQuery] GetAllUserLikedMovieListQueryRequest getAllUserLikedMovieListQueryRequest)
        {
            GetAllUserLikedMovieListQueryResponse response = await _mediator.Send(getAllUserLikedMovieListQueryRequest);
            return Ok(response);
        }
        [HttpPost("add-movie")]
        public async Task<IActionResult> AddMovieToList([FromQuery] AddMovieToListCommandRequest addMovieToListCommandRequest)
        {
            AddMovieToListCommandResponse response = await _mediator.Send(addMovieToListCommandRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSingleMovieList([FromRoute] GetSingleMovieListQueryRequest getSingleMovieListQueryRequest)
        {
            GetSingleMovieListQueryResponse respnose = await _mediator.Send(getSingleMovieListQueryRequest);
            return Ok(respnose);
        }

        [HttpPut("like")]
        public async Task<IActionResult> LikeMovieList([FromQuery] LikeMovieListCommandRequest likeMovieListCommandRequest)
        {
            LikeMovieListCommandResponse response = await _mediator.Send(likeMovieListCommandRequest);
            if (response.Success) return Ok(response);
            return BadRequest();
        }

    }
}
