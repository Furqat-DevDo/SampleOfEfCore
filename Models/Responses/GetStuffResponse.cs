using EfCore.Entities.Enums;
using System.Text.Json;

namespace EfCore.Models.Responses;

public class GetStuffResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public EStuffRole Role { get; set; }
    public JsonDocument? PersonalData { get; set; }
    public decimal Salary { get; set; }
    public  string? FullName { get; set; }
}
