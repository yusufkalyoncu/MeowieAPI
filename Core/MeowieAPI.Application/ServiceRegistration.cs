using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MeowieAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            //collection.AddMediatR(typeof(ServiceRegistration)); // this method will find all cqrs classes and import automaticly
            collection.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(ServiceRegistration).Assembly));
        }
    }
}
