using EfCore.Entities.Enums;

namespace EfCore.Models.Requests
{
    public class UpdateStuffRequest
    {
        public required string FullName { get; set; }
        public EStuffRole Role { get; set; }
        public double Salary { get; set; }
    }
}
