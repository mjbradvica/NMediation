// <copyright file="BaseGenericHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;

namespace NMediation.Samples.CommonWeather
{
    /// <inheritdoc />
    public abstract class BaseGenericHandler<TRequest, TResponse> : BaseProcessingHandler<TRequest, TResponse>
        where TRequest : IPayload<TResponse>
    {
        /// <inheritdoc/>
        protected override Task<TResponse> PostProcessing(TResponse response, CancellationToken cancellationToken)
        {
            return Task.FromResult(response);
        }

        /// <inheritdoc/>
        protected override Task<TRequest> PreProcessing(TRequest payload, CancellationToken cancellationToken)
        {
            return Task.FromResult(payload);
        }
    }
}
