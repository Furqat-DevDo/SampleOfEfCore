using EfCore.Entities.Abstractions;

namespace EfCore.Entities;

public class Storage : BaseEntity
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public List<int> ProductId { get; set; } = new();
}
