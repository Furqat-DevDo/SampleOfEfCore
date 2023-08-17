using System.Runtime.Serialization;

namespace EfCore.Exceptions;

[Serializable]
internal class UnableToSaveStuffChangesException : Exception
{
    public UnableToSaveStuffChangesException()
    {
    }

    public UnableToSaveStuffChangesException(string? message) : base(message)
    {
    }

    public UnableToSaveStuffChangesException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UnableToSaveStuffChangesException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}