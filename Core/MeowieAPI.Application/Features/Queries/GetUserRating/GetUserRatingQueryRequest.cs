using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeowieAPI.Application.Features.Queries.GetUserRating
{
    public class GetUserRatingQueryRequest : IRequest<GetUserRatingQueryResponse>
    {
        public string Username { get; set; }
    }
}
