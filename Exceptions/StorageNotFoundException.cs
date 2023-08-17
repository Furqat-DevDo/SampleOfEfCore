using System.Runtime.Serialization;

namespace EfCore.Exceptions;

[Serializable]
internal class StorageNotFoundException : BaseNotFoundException
{
    public StorageNotFoundException()
    {
    }

    public StorageNotFoundException(string? message) : base(message)
    {
    }

    public StorageNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected StorageNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}