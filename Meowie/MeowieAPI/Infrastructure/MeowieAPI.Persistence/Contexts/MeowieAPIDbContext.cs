using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeowieAPI.Persistence.Contexts
{
    public class MeowieAPIDbContext : DbContext
    {
        public MeowieAPIDbContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieList> MovieLists { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserLikesMovieList>()
                .HasKey(um => new { um.UserId, um.MovieListId });
        }
    }
}
