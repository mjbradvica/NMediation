// <copyright file="TestPayload.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;

namespace NMediation.Tests.TestHandlers
{
    /// <inheritdoc />
    internal class TestPayload : IPayload<string>
    {
        /// <summary>
        /// Gets or sets the initial payload value.
        /// </summary>
        public string Initial { get; set; } = string.Empty;
    }
}
