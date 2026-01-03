// <copyright file="IMediation.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NMediation.Core
{
    /// <summary>
    /// Interface that allows for mediation operations.
    /// </summary>
    public interface IMediation
    {
        /// <summary>
        /// Mediates a payload object.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="payload">An instance of the <see cref="IPayload{TResponse}"/> interface.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<TResponse> Mediate<TResponse>(IPayload<TResponse> payload, CancellationToken cancellationToken = default);

        /// <summary>
        /// Publishes an occurrence to any number of handlers.
        /// </summary>
        /// <typeparam name="TOccurrence">The type of the occurrence.</typeparam>
        /// <param name="occurrence">An instance of the <see cref="IOccurrence"/> interface.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Publish<TOccurrence>(TOccurrence occurrence, CancellationToken cancellationToken = default)
            where TOccurrence : IOccurrence;
    }
}
