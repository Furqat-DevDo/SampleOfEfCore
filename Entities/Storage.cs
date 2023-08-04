using EfCore.Entities.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Entities;

public class Storage : BaseEntity
{
    public required string Name { get; set; }
    public required string  Address { get; set; }

    [ForeignKey(nameof(ProductIds))]
    public List<int> ProductIds { get; set; } = new();
    public virtual Product ? Products { get; set; }
}
