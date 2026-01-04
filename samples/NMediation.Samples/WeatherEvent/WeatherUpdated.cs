// <copyright file="WeatherUpdated.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;

namespace NMediation.Samples.WeatherEvent
{
    /// <inheritdoc />
    public class WeatherUpdated : IOccurrence
    {
        /// <summary>
        /// Gets the occurrence timestamp.
        /// </summary>
        public DateTimeOffset TimeStamp { get; } = DateTimeOffset.UtcNow;
    }
}
