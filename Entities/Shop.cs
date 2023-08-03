using EfCore.Entities.Abstaction;

namespace EfCore.Entities
{
    public class Shop:BaseEntitie
    {
        public required string Name { get; set; }
        public required string Adrress { get; set; }
        public string Phone { get; set; } = null!;
        public int? UpperId { get; set; }
        public Shop? Upper { get; set; }
        public List<Shop>? Branches { get; set; }


    }
}
