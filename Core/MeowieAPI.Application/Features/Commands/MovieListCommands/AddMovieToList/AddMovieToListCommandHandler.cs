using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.Repositories.MovieListRepository;
using MeowieAPI.Application.Repositories.MovieRepository;

namespace MeowieAPI.Application.Features.Commands.MovieListCommands.AddMovieToList
{
    public class AddMovieToListCommandHandler : IRequestHandler<AddMovieToListCommandRequest, AddMovieToListCommandResponse>
    {
        readonly IMovieListReadRepository _movieListReadRepository;
        readonly IMovieListWriteRepository _movieListWriteRepository;
        readonly IMovieReadRepository _movieReadRepository;

        public AddMovieToListCommandHandler(IMovieListReadRepository movieListReadRepository, IMovieReadRepository movieReadRepository, IMovieListWriteRepository movieListWriteRepository)
        {
            _movieListReadRepository = movieListReadRepository;
            _movieReadRepository = movieReadRepository;
            _movieListWriteRepository = movieListWriteRepository;
        }

        public async Task<AddMovieToListCommandResponse> Handle(AddMovieToListCommandRequest request, CancellationToken cancellationToken)
        {
            var movieList = await _movieListReadRepository.GetByIdAsync(request.MovieListId);
            if (movieList == null) return new() { Success = false, Message = "Movie List Not Found"};
            var movie = await _movieReadRepository.GetByIdAsync(request.MovieId);
            if (movie == null) return new() { Success = false, Message = "Movie Not Found"};
            if (movieList.Movies.Contains(movie)) return new() { Success = false, Message = "List already include this movie" };
            movieList.Movies.Add(movie);
            await _movieListWriteRepository.SaveAsync();
            return new() { Success = true, Message = "Movie successfully added to movie list" };
        }
    }
}
