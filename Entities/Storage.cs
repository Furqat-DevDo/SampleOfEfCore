using EfCore.Entities.Abstaction;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Entities
{
    public class Storage:BaseEntitie
    {
        public required string Name { get; set; }
        public required string Adress { get; set; }
        [ForeignKey("ProductIds")]
        public List<int> ProductIds { get; set; }
        public virtual Product Products { get; set; }

    }
}
