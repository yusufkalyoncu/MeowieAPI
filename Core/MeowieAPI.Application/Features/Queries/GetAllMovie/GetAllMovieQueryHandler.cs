using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.DTO;
using MeowieAPI.Application.Repositories.MovieRepository;

namespace MeowieAPI.Application.Features.Queries.GetAllMovie
{
    public class GetAllMovieQueryHandler : IRequestHandler<GetAllMovieQueryRequest, GetAllMovieQueryResponse>
    {
        readonly IMovieReadRepository _movieReadRepository;

        public GetAllMovieQueryHandler(IMovieReadRepository movieReadRepository)
        {
            _movieReadRepository = movieReadRepository;
        }

        public async Task<GetAllMovieQueryResponse> Handle(GetAllMovieQueryRequest request, CancellationToken cancellationToken)
        {
            List<MovieDTO> movies = _movieReadRepository.GetAll().Skip(request.Pagination.Page * request.Pagination.Size).Take(request.Pagination.Size).Select(
                m => new MovieDTO
                {
                    Duration = m.Duration,
                    Genres = m.Genres,
                    Description = m.Description,
                    Id = m.Id,
                    ImageURL = m.ImageURL,
                    BannerURL = m.BannerURL,
                    ImdbRating = m.ImdbRating,
                    UserRating = m.UserRating,
                    Name = m.Name,
                    ReleaseDate = m.ReleaseDate
                }).ToList();

            return new GetAllMovieQueryResponse() { Movies = movies };
        }
    }
}
