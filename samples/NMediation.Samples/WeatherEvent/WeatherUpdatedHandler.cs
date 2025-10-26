// <copyright file="WeatherUpdatedHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NMediation.Samples.WeatherEvent
{
    /// <inheritdoc />
    public class WeatherUpdatedHandler : IOccurrenceHandler<WeatherUpdated>
    {
        /// <inheritdoc/>
        public Task Handle(WeatherUpdated occurrence, CancellationToken cancellationToken)
        {
            Console.WriteLine($"The weather changed at {occurrence.TimeStamp}.");

            return Task.CompletedTask;
        }
    }
}
