using System.Runtime.Serialization;

namespace EfCore.Exceptions;

[Serializable]
internal class UnableToSaveShopChangesException : Exception
{
    public UnableToSaveShopChangesException()
    {
    }

    public UnableToSaveShopChangesException(string? message) : base(message)
    {
    }

    public UnableToSaveShopChangesException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UnableToSaveShopChangesException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}