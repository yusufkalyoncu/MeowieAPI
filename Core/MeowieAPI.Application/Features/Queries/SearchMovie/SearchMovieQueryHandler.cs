using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.DTO;
using MeowieAPI.Application.Repositories.MovieRepository;
using Microsoft.EntityFrameworkCore;

namespace MeowieAPI.Application.Features.Queries.SearchMovie
{
    public class SearchMovieQueryHandler : IRequestHandler<SearchMovieQueryRequest, SearchMovieQueryResponse>
    {
        readonly IMovieReadRepository _movieReadRepository;

        public SearchMovieQueryHandler(IMovieReadRepository movieReadRepository)
        {
            _movieReadRepository = movieReadRepository;
        }

        public async Task<SearchMovieQueryResponse> Handle(SearchMovieQueryRequest request, CancellationToken cancellationToken)
        {
            var searchKeyword = request.SearchKeyword.ToLower();

            var foundMoviesCount = await _movieReadRepository.GetAll()
                .Where(m => m.Name.ToLower().Contains(searchKeyword)).CountAsync();

            var foundMovies = await _movieReadRepository.GetAll()
                .Where(m => m.Name.ToLower().Contains(searchKeyword))
                .Skip(request.Count * request.Page)
                .Take(request.Count)
                .Select(m => new MovieDTO()
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description,
                    Duration = m.Duration,
                    Genres = m.Genres,
                    ImdbRating = m.ImdbRating,
                    UserRating = m.UserRating,
                    ReleaseDate = m.ReleaseDate,
                    BannerURL = m.BannerURL,
                    ImageURL = m.ImageURL
                })
                .ToListAsync();
            return new() { Movies = foundMovies, TotalMovieCount = foundMoviesCount };

        }
    }
}
