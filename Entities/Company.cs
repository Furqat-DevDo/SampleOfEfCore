using EfCore.Entities.Abstaction;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Entities
{
    public class Company:BaseEntitie
    {
        
        public required string Name { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int? UpperId { get; set; }
        public Company? Upper { get; set; }
        public List<Company>? Branches { get; set; }
    }
}
