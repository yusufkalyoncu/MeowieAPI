using MediatR;
using MeowieAPI.Application.Features.Queries.GetSingleComment;
using MeowieAPI.Application.Features.Queries.GetUserRating;
using Microsoft.AspNetCore.Mvc;

namespace MeowieAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("single-comment")]
        public async Task<IActionResult> GetSingleComment([FromQuery] GetSingleCommentQueryRequest getSingleCommentQueryRequest)
        {
            GetSingleCommentQueryResponse response = await _mediator.Send(getSingleCommentQueryRequest);
            return Ok(response);
        }

        [HttpGet("user-ratings")]
        public async Task<IActionResult> GetUserRatings([FromQuery] GetUserRatingQueryRequest getUserRatingQueryRequest)
        {
            GetUserRatingQueryResponse response = await _mediator.Send(getUserRatingQueryRequest);
            return Ok(response);
        }
    }
}
