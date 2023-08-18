using EfCore.Attributes;
using EfCore.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace EfCore.Models.Requests;

public class CreateStuffRequest
{
    [StringValidator(MinLength = 3,
    ErrorMessage = "Kamida")]
    public string FullName { get; set; } = string.Empty;

    [EnumDataType(typeof(EStuffRole))]
    public EStuffRole Role { get; set; }
    public JsonDocument? PersonalData { get; set; }
    [Range(1000,100000000)]
    public decimal Salary { get; set; }
}
