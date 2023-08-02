namespace EfCore.Entities.Abstractions;

public abstract class BaseEntity
{
    public virtual int Id { get; set; } 
    public virtual DateTime CreatedTime { get; set; }
    public virtual DateTime? UpdatedTime { get; set; }
    public virtual bool IsActive { get; set; }
}
