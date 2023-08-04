using System.ComponentModel.DataAnnotations.Schema;
using EfCore.Entities;

namespace EfCore.Models.Requests;

public class UpdateProductRequest
{
    public required string Name { get; set; }
    public string? ImageSrc { get; set; }

    [ForeignKey("CategoryId")]
    public required int CategoryId { get; set; }

    public virtual Category? Categories { get; set; }

    [ForeignKey("CompanyId")]
    public required int CompanyId { get; set; }

    public virtual Company? Companies { get; set; }
    public DateTime ManufacturedDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime UpDatedDate { get; set; }
}