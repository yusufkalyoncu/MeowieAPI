using MeowieAPI.Application.Repositories.ActorRepository;
using MeowieAPI.Application.Repositories.CommentRepository;
using MeowieAPI.Application.Repositories.DirectorRepository;
using MeowieAPI.Application.Repositories.MovieListRepository;
using MeowieAPI.Application.Repositories.MovieRepository;
using MeowieAPI.Application.Repositories.UserRepository;
using MeowieAPI.Persistence.Repositories.ActorRepository;
using MeowieAPI.Persistence.Repositories.CommentRepository;
using MeowieAPI.Persistence.Repositories.DirectorRepository;
using MeowieAPI.Persistence.Repositories.MovieListRepository;
using MeowieAPI.Persistence.Repositories.MovieRepository;
using MeowieAPI.Persistence.Repositories.UserRepository;
using MeowieAPI.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MeowieAPI.Persistence.Services;
using MeowieAPI.Application.Abstractions.ImdbService;

namespace MeowieAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<MeowieAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

            services.AddScoped<IActorReadRepository, ActorReadRepository>();
            services.AddScoped<IActorWriteRepository, ActorWriteRepository>();

            services.AddScoped<ICommentReadRepository, CommentReadRepository>();
            services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();

            services.AddScoped<IDirectorReadRepository, DirectorReadRepository>();
            services.AddScoped<IDirectorWriteRepository, DirectorWriteRepository>();

            services.AddScoped<IMovieReadRepository, MovieReadRepository>();
            services.AddScoped<IMovieWriteRepository, MovieWriteRepository>();

            services.AddScoped<IMovieListReadRepository, MovieListReadRepository>();
            services.AddScoped<IMovieListWriteRepository, MovieListWriteRepository>();

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            services.AddScoped<IImdbService, ImdbService>();
        }
    }
}
