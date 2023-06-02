using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.Abstractions.Services;
using MeowieAPI.Application.DTO.MovieListDTOs;

namespace MeowieAPI.Application.Features.Queries.GetUserProfile
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQueryRequest, GetUserProfileQueryResponse>
    {
        readonly IUserService _userService;

        public GetUserProfileQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserProfileQueryResponse> Handle(GetUserProfileQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByUsername(request.Username);
            if (user == null) return new GetUserProfileQueryResponse() { User = null };
            return new GetUserProfileQueryResponse()
            {
                User = new()
                {
                    Name = user.Name,
                    Username = user.UserName,
                    Email = user.Email,
                    ProfileImage = user.ProfileImage,
                    Biography = user.Biography,
                    CommentCount = user.Comments.Count(),
                    FollowCount = user.Follows.Count(),
                    LikedMovieListCounts = user.LikedMovieLists.Count(),
                    MovieListCount = user.MovieLists.Count(),
                    /*
                     * MovieLists = user.MovieLists.Select(ml => new MovieListCardDTO()
                    {
                        Id = ml.Id,
                        LikesCount = ml.Likes.Count(),
                        MovieCount = ml.Movies.Count(),
                        Title = ml.Title
                    }).ToList()
                     */

                }
            };
        }
    }
}
