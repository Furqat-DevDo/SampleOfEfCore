using EfCore.Entities.Abstaction;
using EfCore.Entities.Enums;
using System.Text.Json;

namespace EfCore.Entities
{
    public class Stuff:BaseEntitie
    {
        public required string FullName { get; set; }
        public EStuffRole Role  { get; set; }
        public JsonDocument? PersonalData { get; set; }
        public double Salary { get; set; }
    }
}
