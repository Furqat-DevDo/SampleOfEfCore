namespace EfCore.Models.Requests;

public class CreateProductRequest
{
    public required string Name { get; set; }
    public required int CategoryId { get; set; }
    public required int CompanyId { get; set; }
    public DateTime ManufacturedDate { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Price { get; set; }

}
