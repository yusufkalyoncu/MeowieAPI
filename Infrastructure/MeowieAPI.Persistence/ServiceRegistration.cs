using MeowieAPI.Application.Repositories.ActorRepository;
using MeowieAPI.Application.Repositories.CommentRepository;
using MeowieAPI.Application.Repositories.DirectorRepository;
using MeowieAPI.Application.Repositories.MovieListRepository;
using MeowieAPI.Application.Repositories.MovieRepository;
using MeowieAPI.Persistence.Repositories.ActorRepository;
using MeowieAPI.Persistence.Repositories.CommentRepository;
using MeowieAPI.Persistence.Repositories.DirectorRepository;
using MeowieAPI.Persistence.Repositories.MovieListRepository;
using MeowieAPI.Persistence.Repositories.MovieRepository;
using MeowieAPI.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MeowieAPI.Persistence.Services;
using MeowieAPI.Application.Abstractions.ImdbService;
using MeowieAPI.Domain.Entities.Identity;
using MeowieAPI.Domain.Entities;
using MeowieAPI.Application.Abstractions.Services;

namespace MeowieAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<MeowieAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddIdentity<User, Role>(
                options =>
                {
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireDigit = false;
                    
                }).AddEntityFrameworkStores<MeowieAPIDbContext>();

            services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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

            services.AddScoped<IImdbService, ImdbService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();        }
    }
}
