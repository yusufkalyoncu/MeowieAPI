using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MeowieAPI.Application.Repositories.MovieRepository;
using MeowieAPI.Domain.Entities;

namespace MeowieAPI.Application.Features.Commands.AddMovieBanner
{
    public class AddMovieBannerCommandHandler : IRequestHandler<AddMovieBannerCommandRequest, AddMovieBannerCommandResponse>
    {
        readonly IMovieReadRepository _movieReadRepository;
        readonly IMovieWriteRepository _movieWriteRepository;

        public AddMovieBannerCommandHandler(IMovieReadRepository movieReadRepository, IMovieWriteRepository movieWriteRepository)
        {
            _movieReadRepository = movieReadRepository;
            _movieWriteRepository = movieWriteRepository;
        }

        public async Task<AddMovieBannerCommandResponse> Handle(AddMovieBannerCommandRequest request, CancellationToken cancellationToken)
        {
            Movie movie = await _movieReadRepository.GetByIdAsync(request.Id);
            if (movie != null)
            {
                movie.BannerURL = request.BannerURL;
                await _movieWriteRepository.SaveAsync();
                return new();
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
