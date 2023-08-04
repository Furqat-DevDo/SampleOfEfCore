using EfCore.Entities;

namespace EfCore.Models.Requests;

public class UpdateProductRequest
{
    public string Name { get; set; }
    public string? ImageSrc { get; set; }
    public Category? Categories { get; set; }
    public Company? Companies { get; set; }
    public DateTime ManufacturedDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public int CompanyId { get; set; }
}
