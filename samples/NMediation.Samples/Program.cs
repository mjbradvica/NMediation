// <copyright file="Program.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using NMediation.Abstractions;
using NMediation.Dependencies;
using NMediation.Samples.CommonWeather;
using NMediation.Samples.UpdateWeather;
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

            await mediator.Mediate(new UpdateWeatherPayload(), CancellationToken.None);

            await mediator.Mediate(new GetWeatherRequest(), CancellationToken.None);

            var result = await mediator.Mediate(new WeatherRequest(), CancellationToken.None);

            foreach (var weather in result.Weather)
            {
                Console.WriteLine(weather);
            }

            await mediator.Publish(new WeatherUpdated(), CancellationToken.None);
        }
    }
}
