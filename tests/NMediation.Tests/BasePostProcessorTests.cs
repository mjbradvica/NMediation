// <copyright file="BasePostProcessorTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;
using NMediation.Tests.BaseHandlers;
using NMediation.Tests.TestHandlers;

namespace NMediation.Tests
{
    /// <summary>
    /// Test for the <see cref="BasePostProcessingHandler{TPayload,TResponse}"/> class.
    /// </summary>
    [TestClass]
    public class BasePostProcessorTests
    {
        /// <summary>
        /// Do work is called correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task DoWorkPerformsAction()
        {
            var handler = new TestBasePostProcessor();

            var result = await handler.Handle(new TestPayload(), CancellationToken.None);

            Assert.Contains("DoWork", result);
        }

        /// <summary>
        /// Post-processing is called correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task PostProcessingPerformsAction()
        {
            var handler = new TestBasePostProcessor();

            var result = await handler.Handle(new TestPayload(), CancellationToken.None);

            Assert.Contains("PostProcessing", result);
        }
    }
}
