using System.Runtime.Serialization;

namespace EfCore.Exceptions
{
    [Serializable]
    internal class UnableToSaveProductChangesException : Exception
    {
        public UnableToSaveProductChangesException()
        {
        }

        public UnableToSaveProductChangesException(string? message) : base(message)
        {
        }

        public UnableToSaveProductChangesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnableToSaveProductChangesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}