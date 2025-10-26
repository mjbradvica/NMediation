// <copyright file="TestOccurrenceHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NMediation.Tests.TestHandlers
{
    /// <inheritdoc />
    internal class TestOccurrenceHandler : IOccurrenceHandler<TestOccurrence>
    {
        /// <inheritdoc/>
        public Task Handle(TestOccurrence occurrence, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
