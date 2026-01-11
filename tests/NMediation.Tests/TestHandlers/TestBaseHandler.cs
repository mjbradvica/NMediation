// <copyright file="TestBaseHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;

namespace NMediation.Tests.TestHandlers
{
    /// <inheritdoc />
    internal class TestBaseHandler : BaseProcessingHandler<TestPayload, string>
    {
        /// <inheritdoc/>
        protected override Task<string> DoWork(TestPayload payload, CancellationToken cancellationToken)
        {
            return Task.FromResult(payload.Initial + " DoWork");
        }

        /// <inheritdoc/>
        protected override Task<string> PostProcessing(string response, CancellationToken cancellationToken)
        {
            return Task.FromResult(response + " PostProcessing");
        }

        /// <inheritdoc/>
        protected override Task<TestPayload> PreProcessing(TestPayload payload, CancellationToken cancellationToken)
        {
            payload.Initial = "PreProcessing";

            return Task.FromResult(payload);
        }
    }
}
