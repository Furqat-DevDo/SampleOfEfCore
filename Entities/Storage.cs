using EfCore.Entities.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EfCore.Entities;

public class Storage : BaseEntity
{
    public required string Name { get; set; }
    public required string Address { get; set; }

    [ForeignKey("ProductIds")]
    public List<int> ProductIds { get; set; } = new();
    public virtual Product? Products { get; set; }
}
