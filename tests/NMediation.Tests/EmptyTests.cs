// <copyright file="EmptyTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NMediation.Core;

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
        public void Empty_Instance_IsNull()
        {
            var instance = Empty.Instance;

            Assert.IsNull(instance);
        }
    }
}
