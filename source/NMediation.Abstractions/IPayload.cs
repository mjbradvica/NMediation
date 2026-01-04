// <copyright file="IPayload.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NMediation.Abstractions
{
    /// <summary>
    /// A payload to send to a handler.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response object.</typeparam>
    public interface IPayload<TResponse>
    {
    }
}
