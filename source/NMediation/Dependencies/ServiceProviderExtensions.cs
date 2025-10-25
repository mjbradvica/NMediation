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
            if (assemblies.Length == 0)
            {
                throw new ArgumentNullException(nameof(assemblies), "No assemblies were provided to register.");
            }

            services.AddTransient<IMediation, Mediation>();

            foreach (var assembly in assemblies)
            {
                RegisterTypes(assembly, services, typeof(IPayloadHandler<,>));
                RegisterTypes(assembly, services, typeof(IOccurrenceHandler<>));
            }
        }

        private static void RegisterTypes(Assembly assembly, IServiceCollection services, Type handlerType)
        {
            assembly.GetTypes()
                .Where(type => !type.IsAbstract && !type.IsInterface)
                .Where(type => type.GetInterfaces().Any(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == handlerType))
                .ToList()
                .ForEach(implementationType =>
                {
                    var interfaceType = implementationType.GetInterfaces().FirstOrDefault(type => type.GetGenericTypeDefinition() == handlerType);

                    if (interfaceType != null)
                    {
                        services.AddTransient(interfaceType, implementationType);
                    }
                });
        }
    }
}
