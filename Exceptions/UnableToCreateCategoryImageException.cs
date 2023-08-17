using System.Runtime.Serialization;

namespace EfCore.Exceptions;

[Serializable]
internal class UnableToCreateCategoryImageException : BaseNotFoundException
{
    public UnableToCreateCategoryImageException()
    {
    }

    public UnableToCreateCategoryImageException(string? message) : base(message)
    {
    }

    public UnableToCreateCategoryImageException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UnableToCreateCategoryImageException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}