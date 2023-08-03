using EfCore.Entities.Abstaction;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Entities
{
    public class Product:BaseEntitie
    {
        public required string Name { get; set; }
        public string? ImageSrc { get; set; }
        [ForeignKey("CategoryId")]
        public required int CategoryId { get; set; }
        [ForeignKey("CompanyId")]
        public required int CompanyId { get; set; }
        public DateTime ManafactureDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Price { get; set; }
    }
}
