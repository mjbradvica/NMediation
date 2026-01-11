// <copyright file="BaseHandlerTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;
using NMediation.Tests.TestHandlers;

namespace NMediation.Tests
{
    /// <summary>
    /// Tests for the <see cref="BaseProcessingHandler{TPayload,TResponse}"/> class.
    /// </summary>
    [TestClass]
    public class BaseHandlerTests
    {
        /// <summary>
        /// Pre-processing is called correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task PreProcessing_PerformsAction()
        {
            var handler = new TestBaseHandler();

            var result = await handler.Handle(new TestPayload(), CancellationToken.None);

            Assert.Contains("PreProcessing", result);
        }

        /// <summary>
        /// Do work is called correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task DoWork_PerformsAction()
        {
            var handler = new TestBaseHandler();

            var result = await handler.Handle(new TestPayload(), CancellationToken.None);

            Assert.Contains("DoWork", result);
        }

        /// <summary>
        /// Post-processing is called correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task PostProcessing_PerformsAction()
        {
            var handler = new TestBaseHandler();

            var result = await handler.Handle(new TestPayload(), CancellationToken.None);

            Assert.Contains("PostProcessing", result);
        }
    }
}
