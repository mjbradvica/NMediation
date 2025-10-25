// <copyright file="Program.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NMediation.Dependencies;

namespace NMediation.Samples
{
    /// <summary>
    /// Sample program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Sample main function.
        /// </summary>
        public static void Main()
        {
            var service = new ServiceCollection();

            service.AddNMediation(Assembly.GetExecutingAssembly());

            var provider = service.BuildServiceProvider();
        }
    }
}
