// <copyright file="BasePreProcessorTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;
using NMediation.Tests.BaseHandlers;
using NMediation.Tests.TestHandlers;

namespace NMediation.Tests
{
    /// <summary>
    /// Tests for the <see cref="BasePreProcessingHandler{TPayload,TResponse}"/> class.
    /// </summary>
    [TestClass]
    public class BasePreProcessorTests
    {
        /// <summary>
        /// Pre-processing is called correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task PreProcessingPerformsAction()
        {
            var handler = new TestBasePreProcessor();

            var result = await handler.Handle(new TestPayload(), CancellationToken.None);

            Assert.Contains("PreProcessing", result);
        }

        /// <summary>
        /// Do work is called correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task DoWorkPerformsAction()
        {
            var handler = new TestBasePreProcessor();

            var result = await handler.Handle(new TestPayload(), CancellationToken.None);

            Assert.Contains("DoWork", result);
        }
    }
}
