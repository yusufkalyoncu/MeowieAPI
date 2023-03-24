using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeowieAPI.Application.Features.Commands.AddMovieBanner
{
    public class AddMovieBannerCommandRequest : IRequest<AddMovieBannerCommandResponse>
    {
        public string Id { get; set; }
        public string BannerURL { get; set; }
    }
}
