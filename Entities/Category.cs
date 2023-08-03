using EfCore.Entities.Abstaction;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Entities
{
    public class Category:BaseEntitie
    {
        [Column("CategoryName")]
        public required string Name { get; set; }
        public int? UpperId { get; set; }
        public Category? Upper { get; set; }
        public Guid? ImageId { get; set; }
    }
}
