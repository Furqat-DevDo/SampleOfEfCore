using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Entities.Abstractions;

public abstract class BaseEntity
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual int Id { get; set; }
    public virtual DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public virtual DateTime? UpdatedDate { get; set; } = null;

    [DefaultValue(false)]
    public virtual bool IsDeleted { get; set; }
}
