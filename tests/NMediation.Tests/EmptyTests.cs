// <copyright file="EmptyTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;

namespace NMediation.Tests
{
    /// <summary>
    /// Tests for the <see cref="Empty"/> class.
    /// </summary>
    [TestClass]
    public class EmptyTests
    {
        /// <summary>
        /// The instance property of Empty should be null.
        /// </summary>
        [TestMethod]
        public void EmptyInstanceIsNull()
        {
            var instance = Empty.Instance;

            Assert.IsNull(instance);
        }
    }
}
