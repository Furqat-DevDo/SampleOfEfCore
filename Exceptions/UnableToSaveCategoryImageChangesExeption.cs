using System.Runtime.Serialization;

namespace EfCore.Exceptions
{
    [Serializable]
    internal class UnableToSaveCategoryImageChangesExeption : Exception
    {
        public UnableToSaveCategoryImageChangesExeption()
        {
        }

        public UnableToSaveCategoryImageChangesExeption(string? message) : base(message)
        {
        }

        public UnableToSaveCategoryImageChangesExeption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnableToSaveCategoryImageChangesExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}