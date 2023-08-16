using EfCore.Attributes;
using EfCore.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace EfCore.Models.Requests
{
    public class CreateStaffRequest
    {
        [StringValidator(MinLength = 3,
        ErrorMessage = "Kamida")]
        public string FullName { get; set; } = string.Empty;

        [EnumDataType(typeof(EStaffRole))]
        public EStaffRole Role { get; set; }
        public JsonDocument? PersonalData { get; set; }
        [Range(1000,100000000)]
        public double Salary { get; set; }

    }
}

