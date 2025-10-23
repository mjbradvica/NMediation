// <copyright file="ServiceProviderExtensions.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace NMediation.Dependencies
{
    /// <summary>
    /// Extensions for the service provider container.
    /// </summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Adds NMediation to the service container.
        /// </summary>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="assemblies">A collection of <see cref="Assembly"/> to register from.</param>
        public static void AddNMediation(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddTransient<IMediation, Mediation>();

            foreach (var assembly in assemblies)
            {
                assembly.GetTypes()
                    .Where(type => !type.IsAbstract && !type.IsInterface)
                    .Where(type => type.GetInterfaces().Any(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(IPayloadHandler<,>)))
                    .ToList()
                    .ForEach(implementationType =>
                    {
                        var interfaceType = implementationType.GetInterfaces().FirstOrDefault(type => type.GetGenericTypeDefinition() == typeof(IPayloadHandler<,>));

                        if (interfaceType != null)
                        {
                            services.AddTransient(interfaceType, implementationType);
                        }
                    });

                assembly.GetTypes()
                    .Where(type => !type.IsAbstract && !type.IsInterface)
                    .Where(type => type.GetInterfaces().Any(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(IOccurrenceHandler<>)))
                    .ToList()
                    .ForEach(implementationType =>
                    {
                        var interfaceType = implementationType.GetInterfaces().FirstOrDefault(type => type.GetGenericTypeDefinition() == typeof(IOccurrenceHandler<>));

                        if (interfaceType != null)
                        {
                            services.AddTransient(interfaceType, implementationType);
                        }
                    });
            }
        }
    }
}
