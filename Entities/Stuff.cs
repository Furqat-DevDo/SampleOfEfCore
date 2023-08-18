using EfCore.Entities.Abstractions;
using EfCore.Entities.Enums;
using System.Text.Json;

namespace EfCore.Entities;

public class Stuff : BaseEntity
{
    public required string?  FullName { get; set; }
    public EStuffRole Role { get; set; }
    public JsonDocument? PersonalData { get; set; }
    public decimal Salary { get; set; }
}
