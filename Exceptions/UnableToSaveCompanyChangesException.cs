using System.Runtime.Serialization;

namespace EfCore.Exceptions;

[Serializable]
internal class UnableToSaveCompanyChangesException : Exception
{
    public UnableToSaveCompanyChangesException()
    {
    }

    public UnableToSaveCompanyChangesException(string? message) : base(message)
    {
    }

    public UnableToSaveCompanyChangesException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UnableToSaveCompanyChangesException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}