using System.Runtime.Serialization;

namespace EfCore.Exceptions
{
    [Serializable]
    internal class UnableToSaveProductImageChangesExeption : BaseNotFoundException
    {
        public UnableToSaveProductImageChangesExeption()
        {
        }

        public UnableToSaveProductImageChangesExeption(string? message) : base(message)
        {
        }

        public UnableToSaveProductImageChangesExeption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnableToSaveProductImageChangesExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}