using System.Runtime.Serialization;

namespace EfCore.Exceptions
{
    [Serializable]
    internal class CategoryImageNotFoundExeption : Exception
    {
        public CategoryImageNotFoundExeption()
        {
        }

        public CategoryImageNotFoundExeption(string? message) : base(message)
        {
        }

        public CategoryImageNotFoundExeption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CategoryImageNotFoundExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}