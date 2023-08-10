namespace EfCore.Entities.Abstractions;

public abstract class BaseFile  : BaseEntity
{
    public Guid Id { get; set; }
    public virtual string Extension { get; set; } = null!;
    public virtual long Size { get; set; }
    public virtual string Src { get; set; } = null!;
    

}
