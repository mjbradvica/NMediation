// <copyright file="WeatherHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NMediation.Samples.Weather
{
    /// <inheritdoc />
    public class WeatherHandler : IPayloadHandler<WeatherRequest, WeatherResponse>
    {
        /// <inheritdoc/>
        public async Task<WeatherResponse> Handle(WeatherRequest payload, CancellationToken cancellationToken)
        {
            await Task.Delay(0, cancellationToken);

            return new WeatherResponse
            {
                Weather = new List<string>
                {
                    "hot",
                    "rainy",
                    "windy",
                    "humid",
                },
            };
        }
    }
}
