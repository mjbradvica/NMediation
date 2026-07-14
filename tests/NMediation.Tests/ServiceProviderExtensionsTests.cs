// <copyright file="ServiceProviderExtensionsTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using NMediation.Abstractions;
using NMediation.Dependencies;
using NMediation.Tests.TestHandlers;
using System.Reflection;

namespace NMediation.Tests
{
    /// <summary>
    /// Tests for the <see cref="ServiceProviderExtensions"/> class.
    /// </summary>
    [TestClass]
    public class ServiceProviderExtensionsTests
    {
        private readonly ServiceCollection _serviceCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProviderExtensionsTests"/> class.
        /// </summary>
        public ServiceProviderExtensionsTests()
        {
            _serviceCollection = new ServiceCollection();
        }

        /// <summary>
        /// No assemblies pass to registration throws an exception.
        /// </summary>
        [TestMethod]
        public void AddNMediationNoAssembliesThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => _serviceCollection.AddNMediation());
        }

        /// <summary>
        /// Ensures all dependencies are registered correctly.
        /// </summary>
        [TestMethod]
        public void AddNMediationRegistersHandlers()
        {
            _serviceCollection.AddNMediation(Assembly.GetExecutingAssembly());

            var provider = _serviceCollection.BuildServiceProvider();

            Assert.IsNotNull(provider.GetService<IMediation>());
            Assert.IsNotNull(provider.GetService<IOccurrenceHandler<TestOccurrence>>());
            Assert.IsNotNull(provider.GetService<IPayloadHandler<TestPayload, string>>());
        }

        /// <summary>
        /// Mediation can instantiate handlers.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task MediationCanInstantiatePayloadHandler()
        {
            _serviceCollection.AddNMediation(Assembly.GetExecutingAssembly());

            var provider = _serviceCollection.BuildServiceProvider();

            var mediator = provider.GetRequiredService<IMediation>();

            var payloadResult = await mediator.Mediate(new TestPayload(), CancellationToken.None);

            Assert.IsNotNull(payloadResult);
        }

        /// <summary>
        /// Mediation can instantiate occurrence handlers.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task MediationCanInstantiateOccurrenceHandler()
        {
            _serviceCollection.AddNMediation(Assembly.GetExecutingAssembly());

            var provider = _serviceCollection.BuildServiceProvider();

            var mediator = provider.GetRequiredService<IMediation>();

            await mediator.Publish(new TestOccurrence(), CancellationToken.None);
        }

        /// <summary>
        /// No handler defines, throws exception.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task MediationNoHandlersDefinesThrowsException()
        {
            _serviceCollection.AddNMediation(Assembly.GetExecutingAssembly());

            var provider = _serviceCollection.BuildServiceProvider();

            var mediator = provider.GetRequiredService<IMediation>();

            await Assert.ThrowsAsync<ArgumentNullException>(async () => await mediator.Mediate(new MissingHandlerRequest(), CancellationToken.None));
        }
    }
}
