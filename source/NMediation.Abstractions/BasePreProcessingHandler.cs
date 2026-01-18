// <copyright file="BasePreProcessingHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NMediation.Abstractions
{
    /// <inheritdoc />
    public abstract class BasePreProcessingHandler<TPayload, TResponse> : IPayloadHandler<TPayload, TResponse>
        where TPayload : IPayload<TResponse>
    {
        /// <inheritdoc/>
        public async Task<TResponse> Handle(TPayload payload, CancellationToken cancellationToken)
        {
            var updatedPayload = await PreProcessing(payload, cancellationToken);

            return await DoWork(updatedPayload, cancellationToken);
        }

        /// <summary>
        /// Executes any pre-processing functionality before the handler main job.
        /// </summary>
        /// <param name="payload">An instance of the payload object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected abstract Task<TPayload> PreProcessing(TPayload payload, CancellationToken cancellationToken);

        /// <summary>
        /// Executes the core functionality of the handler.
        /// </summary>
        /// <param name="payload">An instance of the payload object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected abstract Task<TResponse> DoWork(TPayload payload, CancellationToken cancellationToken);
    }
}
