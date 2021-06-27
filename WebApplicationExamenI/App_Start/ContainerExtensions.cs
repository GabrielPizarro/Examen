using BD;
using WBL;
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
            services.AddTransient<IDepartamentosService, DepartamentosService>();            
            services.AddTransient<ITitulosService, TitulosService>();
            services.AddTransient<IPuestosService, PuestosService>();
            return services;
        }
    }
}
