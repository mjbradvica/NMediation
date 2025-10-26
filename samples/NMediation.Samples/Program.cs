// <copyright file="Program.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using NMediation.Dependencies;
using NMediation.Samples.Weather;
using NMediation.Samples.WeatherEvent;
using System.Reflection;

namespace NMediation.Samples
{
    /// <summary>
    /// Sample program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Sample main function.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Main()
        {
            var service = new ServiceCollection();

            service.AddNMediation(Assembly.GetExecutingAssembly());

            var provider = service.BuildServiceProvider();

            var mediator = provider.GetRequiredService<IMediation>();

            var result = await mediator.Mediate(new WeatherRequest(), CancellationToken.None);

            foreach (var weather in result.Weather)
            {
                Console.WriteLine(weather);
            }

            await mediator.Publish(new WeatherUpdated(), CancellationToken.None);
        }
    }
}
