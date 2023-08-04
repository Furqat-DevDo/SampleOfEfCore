using EfCore.Entities.Abstractions;

namespace EfCore.Entities;

public class Shop : BaseEntity
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public string Phone { get; set; } = null!;
    public int? UpperId { get; set; }
    public Shop? Upper { get; set; }
    public List<Shop>? Branches { get; set; }

}
