// <copyright file="PayloadWrapper.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using NMediation.Abstractions;

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
                throw new ArgumentNullException(nameof(payload), "The handler for the payload was not found.");
            }

            return await handler.Handle((TPayload)payload, cancellationToken);
        }
    }
}
