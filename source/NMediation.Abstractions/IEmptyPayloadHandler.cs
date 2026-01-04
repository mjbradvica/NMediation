// <copyright file="IEmptyPayloadHandler.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace NMediation.Abstractions
{
    /// <inheritdoc />
    public interface IEmptyPayloadHandler<in TPayload> : IPayloadHandler<TPayload, Empty>
        where TPayload : IEmptyPayload
    {
    }
}
