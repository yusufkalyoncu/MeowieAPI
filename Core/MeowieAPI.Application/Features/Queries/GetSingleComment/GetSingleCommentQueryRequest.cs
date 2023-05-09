using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MeowieAPI.Application.Features.Queries.GetSingleComment
{
    public class GetSingleCommentQueryRequest : IRequest<GetSingleCommentQueryResponse>
    {
        public string Username { get; set; }
        public Guid MovieId { get; set; }
    }
}
