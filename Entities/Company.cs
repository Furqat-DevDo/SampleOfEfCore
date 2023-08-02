using EfCore.Entities.Abstractions;

namespace EfCore.Entities;

public class Company : BaseEntity
{
    public required string Name { get; set; }
    public DateTime? ClasedDate { get; set; }
    public int? UpperId { get; set; }
    public Company? Upper { get; set; }
    public List<Company>? Branches { get; set; }
        
}
