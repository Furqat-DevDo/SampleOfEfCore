using System.Runtime.Serialization;

namespace EfCore.Exceptions
{
    [Serializable]
    internal class StuffNotFoundExeption : BaseNotFoundException
    {
        public StuffNotFoundExeption()
        {
        }

        public StuffNotFoundExeption(string? message) : base(message)
        {
        }

        public StuffNotFoundExeption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected StuffNotFoundExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}