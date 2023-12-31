﻿using System.Runtime.Serialization;

namespace EfCore.Exceptions;

[Serializable]
public class ProductNotFoundException : BaseNotFoundException
{
    public ProductNotFoundException()
    {
    }

    public ProductNotFoundException(string? message) : base(message)
    {
    }

    public ProductNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ProductNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}