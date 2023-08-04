using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Entities.Abstractions;

public abstract class BaseEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual int Id { get; set; } 
    public virtual DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    public virtual DateTime? UpdatedTime { get; set; }
    
    [DefaultValue(false)]
    public virtual bool IsDeleted { get; set; }
}
