using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.DTO;
using MeowieAPI.Application.Repositories.MovieRepository;

namespace MeowieAPI.Application.Features.Queries.GetRandomMovie
{
    public class GetRandomMovieQueryHandler : IRequestHandler<GetRandomMovieQueryRequest, GetRandomMovieQueryResponse>
    {
        readonly IMovieReadRepository _movieReadRepository;

        public GetRandomMovieQueryHandler(IMovieReadRepository movieReadRepository)
        {
            _movieReadRepository = movieReadRepository;
        }

        public async Task<GetRandomMovieQueryResponse> Handle(GetRandomMovieQueryRequest request, CancellationToken cancellationToken)
        {
            int movieCount = _movieReadRepository.GetAll().Count();
            Random r = new Random();
            int random = r.Next(movieCount - request.Count);
            List<MovieDTO> movies = _movieReadRepository.GetAll(false).Skip(random).Take(request.Count).Select(
                m => new MovieDTO
                {
                    Id = m.Id,
                    Duration = m.Duration,
                    Genres = m.Genres,
                    Description = m.Description,
                    ImageURL = m.ImageURL,
                    BannerURL = m.BannerURL,
                    ImdbRating = m.ImdbRating,
                    UserRating = m.UserRating,
                    Name = m.Name,
                    ReleaseDate = m.ReleaseDate
                }).ToList();
            return new GetRandomMovieQueryResponse() { Movies = movies };
        }
    }
}
