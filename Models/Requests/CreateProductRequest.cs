using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Models.Requests;

public class CreateProductRequest
{
    public required string Name { get; set; }
    public string? ImageSrc { get; set; }

    [ForeignKey("Id")]
    public required int CategoryId { get; set; }

    [ForeignKey("CompanyId")]
    public required int CompanyId { get; set; }
    public DateTime ManufacturedDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime UpDatedDate { get; set; }
    
}