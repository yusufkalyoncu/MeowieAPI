using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.Repositories;
using MeowieAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MeowieAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly MeowieAPIDbContext _context;

        public ReadRepository(MeowieAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
        {
            return Table;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        {
            return Table.Where(method);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            return await Table.FirstOrDefaultAsync(method);
        }

        public Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
