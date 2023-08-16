using System.Runtime.Serialization;

namespace EfCore.Exceptions;

[Serializable]
internal class ShopNotFoundException : BaseNotFoundException
{
    public ShopNotFoundException()
    {
    }

    public ShopNotFoundException(string? message) : base(message)
    {
    }

    public ShopNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ShopNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}