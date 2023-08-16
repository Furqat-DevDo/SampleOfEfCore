using System.Runtime.Serialization;

namespace EfCore.Exceptions;
public class CompanyNotFoundException : BaseNotFoundException
{
    public CompanyNotFoundException()
    {
    }

    public CompanyNotFoundException(string? message) : base(message)
    {
    }

    public CompanyNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected CompanyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}