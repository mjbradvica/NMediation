// <copyright file="BaseProcessingHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NMediation.Abstractions
{
    /// <inheritdoc />
    public abstract class BaseProcessingHandler<TPayload, TResponse> : IPayloadHandler<TPayload, TResponse>
        where TPayload : IPayload<TResponse>
    {
        /// <inheritdoc/>
        public virtual async Task<TResponse> Handle(TPayload payload, CancellationToken cancellationToken)
        {
            var updatedPayload = await PreProcessing(payload, cancellationToken);

            var response = await DoWork(updatedPayload, cancellationToken);

            return await PostProcessing(response, cancellationToken);
        }

        /// <summary>
        /// Executes any pre-processing functionality before the handler main job.
        /// </summary>
        /// <param name="payload">An instance of the <see cref="TPayload"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected abstract Task<TPayload> PreProcessing(TPayload payload, CancellationToken cancellationToken);

        /// <summary>
        /// Executes the core functionality of the handler.
        /// </summary>
        /// <param name="payload">An instance of the <see cref="TPayload"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected abstract Task<TResponse> DoWork(TPayload payload, CancellationToken cancellationToken);

        /// <summary>
        /// Executes the post-processing functionality after the handler main job.
        /// </summary>
        /// <param name="response">An instance of the <see cref="TResponse"/> object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        protected abstract Task<TResponse> PostProcessing(TResponse response, CancellationToken cancellationToken);
    }
}
