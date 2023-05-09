using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.Repositories.CommentRepository;
using MeowieAPI.Domain.Entities;
using MeowieAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MeowieAPI.Persistence.Repositories.CommentRepository
{
    public class CommentReadRepository : ReadRepository<Comment>, ICommentReadRepository
    {
        private readonly MeowieAPIDbContext _context;
        public CommentReadRepository(MeowieAPIDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Comment> GetCommentByUserIdAndMovieIdAsync(string userId, Guid movieId)
        {
            try
            {
                Comment? comment = await _context.Comments
                .Include(c => c.User)
                .Include(c => c.Movie)
                .FirstOrDefaultAsync(c => c.User.Id == userId && c.Movie.Id == movieId);
                return comment;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
