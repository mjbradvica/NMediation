// <copyright file="IPayloadWrapper.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NMediation.Dependencies
{
    /// <summary>
    /// Allows for the container to resolve a payload handler.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    internal interface IPayloadWrapper<TResponse>
    {
        /// <summary>
        /// Resolves the correct handles and executes.
        /// </summary>
        /// <param name="payload">An instance of the <see cref="IPayload{TResponse}"/> interface.</param>
        /// <param name="serviceProvider">An instance of the <see cref="IServiceProvider"/> interface.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<TResponse> Execute(IPayload<TResponse> payload, IServiceProvider serviceProvider, CancellationToken cancellationToken);
    }
}
