using EfCore.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace EfCore.Models.Requests
{
    public class UpdateStuffRequest
    {
        [Required,MinLength(3),MaxLength(30)]
        public string FullName { get; set; } = string.Empty;

        public EStuffRole Role { get; set; }
        [Range(1000,15000000.00)]
        public double Salary { get; set; }

        public JsonDocument? PersonalData { get; set; } 

    }
}
