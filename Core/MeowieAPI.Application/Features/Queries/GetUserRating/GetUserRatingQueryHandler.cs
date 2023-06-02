using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.Abstractions.Services;
using MeowieAPI.Application.DTO.UserDTOs;
using MeowieAPI.Application.Exceptions;

namespace MeowieAPI.Application.Features.Queries.GetUserRating
{
    public class GetUserRatingQueryHandler : IRequestHandler<GetUserRatingQueryRequest, GetUserRatingQueryResponse>
    {
        readonly IUserService _userService;

        public GetUserRatingQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserRatingQueryResponse> Handle(GetUserRatingQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Username == null) throw new UserNotFoundException();
            var user = await _userService.GetUserByUsername(request.Username);
            if(user == null) throw new UserNotFoundException();

            List<UserRatedMovieCardDTO> ratedMovies;

            ratedMovies = user.Comments.Select(c => new UserRatedMovieCardDTO()
            {
                RatingId = c.Id.ToString(),
                Username = user.UserName,
                ProfileImage = user.ProfileImage,
                MovieId = c.MovieId.ToString(),
                MovieName = c.Movie.Name,
                MovieImage = c.Movie.ImageURL,
                Rating = c.UserRating,
                Comment = c.Content,
                ImdbRating = c.Movie.ImdbRating,
                UserRating = c.Movie.UserRating
            }).ToList();

            return new() { RatedMovies = ratedMovies };
        }
    }
}
