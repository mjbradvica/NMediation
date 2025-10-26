// <copyright file="TestPayloadHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NMediation.Tests.TestHandlers
{
    /// <inheritdoc />
    internal class TestPayloadHandler : IPayloadHandler<TestPayload, string>
    {
        /// <inheritdoc/>
        public Task<string> Handle(TestPayload payload, CancellationToken cancellationToken)
        {
            return Task.FromResult(string.Empty);
        }
    }
}
