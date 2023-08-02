namespace EfCore.Entities.Abstractions;

public abstract class BaseEntity
{
    public virtual int Id { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime? UpdatedDate { get; set; }
    public virtual bool IsActive { get; set; }
}
