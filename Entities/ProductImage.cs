using EfCore.Entities;
using EfCore.Entities.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

public class ProductImage : BaseFile
{
    [ForeignKey(nameof(ProductId))]
    public required int ProductId { get; set; }
    public virtual Product? Products { get; set; }
}
