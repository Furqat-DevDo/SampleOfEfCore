using EfCore.Entities.Abstractions;

namespace EfCore.Entities;


public class Storage : BaseEntity
{
    public required string Name { get; set; }
    public required string Adrress { get; set; }
    public List<int>? ProductIds { get; set; }
    public virtual Product ? Products { get; set; }
}
