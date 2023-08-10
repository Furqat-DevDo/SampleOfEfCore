namespace EfCore.Models.Responses;

public class GetProductResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public required string Name { get; set; }
    public DateTime ManufacturedDate { get; set; }
    public int CategoryId { get; set; }
    public int CompanyId { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Price { get; set; }
}
