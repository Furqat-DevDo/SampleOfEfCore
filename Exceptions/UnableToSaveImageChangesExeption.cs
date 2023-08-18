using System.Runtime.Serialization;

namespace EfCore.Exceptions;

[Serializable]
internal class UnableToSaveImageChangesExeption : BaseNotFoundException
{
    public UnableToSaveImageChangesExeption()
    {
    }

    public UnableToSaveImageChangesExeption(string? message) : base(message)
    {
    }

    public UnableToSaveImageChangesExeption(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UnableToSaveImageChangesExeption(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}