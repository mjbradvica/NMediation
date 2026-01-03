// <copyright file="IPayloadHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NMediation.Core
{
    /// <summary>
    /// Designates a handler for a payload that returns a response object.
    /// </summary>
    /// <typeparam name="TPayload">The type of the payload.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public interface IPayloadHandler<in TPayload, TResponse>
        where TPayload : IPayload<TResponse>
    {
        /// <summary>
        /// Handles a payload and returns a response object.
        /// </summary>
        /// <param name="payload">The payload object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<TResponse> Handle(TPayload payload, CancellationToken cancellationToken);
    }
}
