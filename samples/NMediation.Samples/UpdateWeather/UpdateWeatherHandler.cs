// <copyright file="UpdateWeatherHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;

namespace NMediation.Samples.UpdateWeather
{
    /// <inheritdoc />
    public class UpdateWeatherHandler : IEmptyPayloadHandler<UpdateWeatherPayload>
    {
        /// <inheritdoc/>
        public async Task<Empty> Handle(UpdateWeatherPayload payload, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Weather was updated at: {DateTimeOffset.UtcNow}");

            await Task.Delay(0, cancellationToken);

            return Empty.Instance;
        }
    }
}
