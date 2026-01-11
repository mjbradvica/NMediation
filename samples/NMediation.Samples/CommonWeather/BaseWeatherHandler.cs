// <copyright file="BaseWeatherHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;
using NMediation.Samples.Weather;

namespace NMediation.Samples.CommonWeather
{
    /// <inheritdoc />
    public class BaseWeatherHandler : BaseProcessingHandler<WeatherRequest, WeatherResponse>
    {
        /// <inheritdoc/>
        protected override Task<WeatherRequest> PreProcessing(WeatherRequest payload, CancellationToken cancellationToken)
        {
            return Task.FromResult(payload);
        }

        /// <inheritdoc/>
        protected override Task<WeatherResponse> DoWork(WeatherRequest payload, CancellationToken cancellationToken)
        {
            return Task.FromResult(new WeatherResponse());
        }

        /// <inheritdoc/>
        protected override Task<WeatherResponse> PostProcessing(WeatherResponse response, CancellationToken cancellationToken)
        {
            return Task.FromResult(new WeatherResponse());
        }
    }
}
