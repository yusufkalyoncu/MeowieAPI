using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeowieAPI.Application.Features.Queries.GetUserProfile
{
    public class GetUserProfileQueryRequest : IRequest<GetUserProfileQueryResponse>
    {
        public string Username { get; set; }
    }
}
