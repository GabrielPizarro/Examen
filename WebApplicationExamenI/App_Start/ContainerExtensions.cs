using BD;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationExamenI
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {

            services.AddSingleton<IDataAccess, DataAccess>();
            //services.AddTransient</*EL SERVICES*/>();
            return services;
        }
    }
}
