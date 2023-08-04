namespace EfCore.Entities.Abstractions;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public string? ImageSrc { get; set; }
    public required int CategoryId { get; set; }
    public required int CompanyId { get; set; }
    public DateTime ManufactureDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public required decimal Price { get; set; }
}