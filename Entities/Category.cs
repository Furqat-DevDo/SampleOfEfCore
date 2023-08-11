using EfCore.Entities.Abstractions;

namespace EfCore.Entities;
public class Category : BaseEntity
{
    public required string Name { get; set; }
    public int? UpperId { get; set; }
    public Category? Upper { get; set; }
    public List<Category>? ChildCategories { get; set; }
}