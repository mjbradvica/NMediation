// <copyright file="IOccurrenceHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NMediation.Abstractions
{
    /// <summary>
    /// Defines an occurrence handler for an event.
    /// </summary>
    /// <typeparam name="TOccurrence">The type of the occurrence.</typeparam>
    public interface IOccurrenceHandler<in TOccurrence>
        where TOccurrence : IOccurrence
    {
        /// <summary>
        /// Handles an occurrence that signifies an important event.
        /// </summary>
        /// <param name="occurrence">An instance of the event to handle.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Handle(TOccurrence occurrence, CancellationToken cancellationToken);
    }
}
