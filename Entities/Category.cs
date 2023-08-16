using EfCore.Entities.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EfCore.Entities;

[Table("Categories")]
public class Category : BaseEntity
{
    [Column("CategoryName", TypeName = "Text")]
    public required string Name { get; set; }
    public int? UpperId { get; set; }
    public Category? Upper { get; set; }    

}
