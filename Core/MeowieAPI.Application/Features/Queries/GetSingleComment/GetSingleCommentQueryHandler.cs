using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.Abstractions.Services;
using MeowieAPI.Application.Repositories.CommentRepository;
using MeowieAPI.Domain.Entities;

namespace MeowieAPI.Application.Features.Queries.GetSingleComment
{
    public class GetSingleCommentQueryHandler : IRequestHandler<GetSingleCommentQueryRequest, GetSingleCommentQueryResponse>
    {
        readonly ICommentReadRepository _commentReadRepository;
        readonly IUserService _userService;

        public GetSingleCommentQueryHandler(ICommentReadRepository commentReadRepository, IUserService userService)
        {
            _commentReadRepository = commentReadRepository;
            _userService = userService;
        }

        public async Task<GetSingleCommentQueryResponse> Handle(GetSingleCommentQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Username == null) return new() { Comment = null};
            var user = await _userService.GetUserByUsername(request.Username);
            var userComment = await _commentReadRepository.GetCommentByUserIdAndMovieIdAsync(user.Id, request.MovieId);
            if (userComment == null) return new() { Comment = null };

            return new() { Comment = new() {
                Content = userComment.Content,
                CreatedDate = userComment.CreatedDate,
                Username = request.Username,
                UserRating = userComment.UserRating } };
        }
    }
}
