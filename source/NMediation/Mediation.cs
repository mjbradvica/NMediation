// <copyright file="Mediation.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using NMediation.Dependencies;

namespace NMediation
{
    /// <inheritdoc />
    public sealed class Mediation : IMediation
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="Mediation"/> class.
        /// </summary>
        /// <param name="serviceProvider">An instance of the <see cref="IServiceProvider"/> interface.</param>
        public Mediation(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        public async Task<TResponse> Mediate<TResponse>(IPayload<TResponse> payload, CancellationToken cancellationToken = default)
        {
            if (Activator.CreateInstance(typeof(PayloadWrapper<,>).MakeGenericType(payload.GetType(), typeof(TResponse))) is IPayloadWrapper<TResponse> wrapper)
            {
                return await wrapper.Execute(payload, _serviceProvider, cancellationToken);
            }

            // Will never hit, but needs to satisfy nullable requirements.
            throw new ArgumentNullException(nameof(payload), "Handler for the payload could not be found.");
        }

        /// <inheritdoc/>
        public async Task Publish<TOccurrence>(TOccurrence occurrence, CancellationToken cancellationToken = default)
            where TOccurrence : IOccurrence
        {
            var handlers = _serviceProvider.GetServices<IOccurrenceHandler<TOccurrence>>();

            foreach (var handler in handlers)
            {
                await handler.Handle(occurrence, cancellationToken);
            }
        }
    }
}
