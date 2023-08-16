using System.Runtime.Serialization;

namespace EfCore.Exceptions
{
    [Serializable]
    internal class UnableToSaveStorageChangesException : Exception
    {
        public UnableToSaveStorageChangesException()
        {
        }

        public UnableToSaveStorageChangesException(string? message) : base(message)
        {
        }

        public UnableToSaveStorageChangesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnableToSaveStorageChangesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}