// <copyright file="BaseWeatherHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;

namespace NMediation.Samples.CommonWeather
{
    /// <inheritdoc />
    public abstract class BaseWeatherHandler : BaseProcessingHandler<GetWeatherRequest, string>
    {
        /// <inheritdoc/>
        protected override Task<GetWeatherRequest> PreProcessing(GetWeatherRequest payload, CancellationToken cancellationToken)
        {
            return Task.FromResult(payload);
        }

        /// <inheritdoc/>
        protected override Task<string> PostProcessing(string response, CancellationToken cancellationToken)
        {
            return Task.FromResult(response);
        }
    }
}
