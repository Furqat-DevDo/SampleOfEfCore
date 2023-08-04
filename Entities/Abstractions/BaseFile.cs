namespace EfCore.Entities.Abstractions;

public abstract class BaseFile : BaseEntity
{
    public new Guid Id { get; set; }
    public virtual string Extension { get; set; } = null!;
    public virtual byte[] Size { get; set; } = new byte[0];
    public virtual string Src { get; set; } = null!;

}
