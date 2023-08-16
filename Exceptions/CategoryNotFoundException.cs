using System.Runtime.Serialization;

namespace EfCore.Exceptions;
public class CategoryNotFoundException : BaseNotFoundException
{
    public CategoryNotFoundException()
    {
        
    }
    public CategoryNotFoundException(string? message) : base(message)
    {
    }

    public CategoryNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected CategoryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}