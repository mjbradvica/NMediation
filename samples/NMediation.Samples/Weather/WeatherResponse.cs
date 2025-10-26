// <copyright file="WeatherResponse.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NMediation.Samples.Weather
{
    /// <summary>
    /// Response class for a <see cref="WeatherRequest"/> class.
    /// </summary>
    public class WeatherResponse
    {
        /// <summary>
        /// Gets the weather.
        /// </summary>
        public IEnumerable<string> Weather { get; init; } = Enumerable.Empty<string>();
    }
}
