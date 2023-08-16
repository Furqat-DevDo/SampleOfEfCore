using System.Runtime.Serialization;

namespace EfCore.Exceptions
{
    [Serializable]
    internal class ProductImageNotFoundExeption : Exception
    {
        public ProductImageNotFoundExeption()
        {
        }

        public ProductImageNotFoundExeption(string? message) : base(message)
        {
        }

        public ProductImageNotFoundExeption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProductImageNotFoundExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}