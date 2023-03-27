using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.Abstractions.Storage;
using MeowieAPI.Application.Abstractions.Token;
using MeowieAPI.Infrastructure.enums;
using MeowieAPI.Infrastructure.Services.Storage;
using MeowieAPI.Infrastructure.Services.Storage.Local;
using MeowieAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace MeowieAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
