using EfCore.Entities;

namespace EfCore.Models.Requests
{
    public class GetShopResponse
    {
        public required string Name { get; set; }
        public required string Adrress { get; set; }
        public string Phone { get; set; } = null!;
        public int? UpperId { get; set; }
        
        public List<Shop>? Branches { get; set; }
    }
}
