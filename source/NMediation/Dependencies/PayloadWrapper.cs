// <copyright file="PayloadWrapper.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;

namespace NMediation.Dependencies
{
    /// <inheritdoc />
    internal sealed class PayloadWrapper<TPayload, TResponse> : IPayloadWrapper<TResponse>
        where TPayload : IPayload<TResponse>
    {
        /// <inheritdoc/>
        public async Task<TResponse> Execute(IPayload<TResponse> payload, IServiceProvider serviceProvider, CancellationToken cancellationToken)
        {
            var handler = serviceProvider.GetService<IPayloadHandler<TPayload, TResponse>>();

            if (handler == null)
            {
                throw new NullReferenceException("Handler was null.");
            }

            return await handler.Handle((TPayload)payload, cancellationToken);
        }
    }
}
