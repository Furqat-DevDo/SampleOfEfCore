using EfCore.Entities.Abstractions;
using EfCore.Entities.Enums;
using System.Text.Json;

namespace EfCore.Entities;

public class Staff : BaseEntity
{
    public required string?  FullName { get; set; }
    public EStaffRole Role { get; set; }
    public JsonDocument? PersonalData { get; set; }
    public double Salary { get; set; }
}
