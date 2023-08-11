using EfCore.Entities.Enums;
using System.Text.Json;

namespace EfCore.Models.Requests
{
    public class CreateStuffRequest
    {
        public string? FullName { get; set; }
        public EStuffRole Role { get; set; }
        public JsonDocument? PersonalData { get; set; }
        public double Salary { get; set; }

    }
}

