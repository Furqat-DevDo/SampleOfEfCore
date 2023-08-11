using EfCore.Entities;
using EfCore.Entities.Enums;

namespace EfCore.Models.Responses
{
    public class GetStuffRespons
    {
        public GetStuffRespons(Stuff entity)
        {
            Id = entity.Id;
            CreatedDate = entity.CreatedDate;
            UpdatedDate = entity.UpdatedDate;
            FullName = entity.FullName;
            Role = entity.Role;
            Salary = entity.Salary;

        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string FullName { get; set; }
        public EStuffRole Role { get; set; }
        public double Salary { get; set; }
    }
}
