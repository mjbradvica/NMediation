// <copyright file="TestBasePreProcessor.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;
using NMediation.Tests.TestHandlers;

namespace NMediation.Tests.BaseHandlers
{
    /// <inheritdoc />
    public class TestBasePreProcessor : BasePreProcessingHandler<TestPayload, string>
    {
        /// <inheritdoc/>
        protected override Task<string> DoWork(TestPayload payload, CancellationToken cancellationToken)
        {
            return Task.FromResult(payload.Initial + " DoWork");
        }

        /// <inheritdoc/>
        protected override Task<TestPayload> PreProcessing(TestPayload payload, CancellationToken cancellationToken)
        {
            payload.Initial = "PreProcessing";

            return Task.FromResult(payload);
        }
    }
}
