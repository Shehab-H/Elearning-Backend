using Application.Intefaces.DataStores;
using Core.Entities.User;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(assembly));
            return services;

        }

        public static IServiceCollection RegisterRepositoriesFromAssembly(this IServiceCollection services, Assembly assembly)
        {
             services.Scan(scan => scan
                       .FromAssemblies(assembly)
                       .AddClasses(classes => classes.AssignableTo(typeof(IRepository)))
                       .AsImplementedInterfaces()
                       .WithScopedLifetime());
            return services;
        }


    }
}
