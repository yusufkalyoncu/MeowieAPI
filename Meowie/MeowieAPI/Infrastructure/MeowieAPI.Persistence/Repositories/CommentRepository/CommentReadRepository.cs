using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.Repositories.CommentRepository;
using MeowieAPI.Domain.Entities;
using MeowieAPI.Persistence.Contexts;

namespace MeowieAPI.Persistence.Repositories.CommentRepository
{
    public class CommentReadRepository : ReadRepository<Comment>, ICommentReadRepository
    {
        public CommentReadRepository(MeowieAPIDbContext context) : base(context)
        {
        }
    }
}
