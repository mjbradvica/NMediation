// <copyright file="GetWeatherHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NMediation.Samples.CommonWeather
{
    /// <inheritdoc />
    public class GetWeatherHandler : BaseWeatherHandler
    {
        /// <inheritdoc/>
        protected override Task<string> DoWork(GetWeatherRequest payload, CancellationToken cancellationToken)
        {
            const string response = "The weather is hot!";

            Console.WriteLine(response);

            return Task.FromResult(response);
        }
    }
}
