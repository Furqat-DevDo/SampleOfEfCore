using EfCore.Entities.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Entities;

public class ProductImage : BaseFile
{
    [ForeignKey(nameof(ProductId))]
    public required int ProductId { get; set; }
    public virtual Product? Products { get; set; }
}