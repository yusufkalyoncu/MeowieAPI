using MediatR;
using MeowieAPI.Application.Features.Commands.AddMovieBanner;
using MeowieAPI.Application.Features.Commands.MovieCommands.RateMovie;
using MeowieAPI.Application.Features.Queries.GetAllMovie;
using MeowieAPI.Application.Features.Queries.GetMovieByGenre;
using MeowieAPI.Application.Features.Queries.GetRandomMovie;
using MeowieAPI.Application.Features.Queries.GetSingleMovie;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeowieAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MoviesController : ControllerBase
    {
        readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovie([FromQuery] GetAllMovieQueryRequest getAllMovieQueryRequest)
        {
            GetAllMovieQueryResponse response = await _mediator.Send(getAllMovieQueryRequest);
            if (response != null) return Ok(response);
            else return NotFound();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSingleMovie([FromRoute]GetSingleMovieQueryRequest getSingleMovieQueryRequest)
        {
            GetSingleMovieQueryResponse response = await _mediator.Send(getSingleMovieQueryRequest);
            if (response != null) return Ok(response);
            else return NotFound();
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandomMovie([FromQuery] GetRandomMovieQueryRequest getRandomMovieQueryRequest)
        {
            GetRandomMovieQueryResponse response = await _mediator.Send(getRandomMovieQueryRequest);
            if (response != null) return Ok(response);
            else return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> AddMovieBanner(AddMovieBannerCommandRequest addMovieBannerCommandRequest)
        {
            await _mediator.Send(addMovieBannerCommandRequest);
            return Ok();
        }

        [HttpGet("genre")]
        public async Task<IActionResult> GetMovieByGenre([FromQuery]GetMovieByGenreQueryRequest getMovieByGenreQueryRequest)
        {
            GetMovieByGenreQueryResponse response = await _mediator.Send(getMovieByGenreQueryRequest);
            if (response != null) return Ok(response);
            else return NotFound();
        }

        [HttpPost("rate")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> RateMovie([FromBody]RateMovieCommandRequest rateMovieCommandRequest)
        {
            RateMovieCommandResponse response = await _mediator.Send(rateMovieCommandRequest);
            if (response.Success) return Ok(response);
            else return BadRequest(response);
        }
    }
}
