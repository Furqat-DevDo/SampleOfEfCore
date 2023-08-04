using EfCore.Entities;

namespace EfCore.Models.Responses;

public class GetProductResponse
{
    public GetProductResponse(Product product)
    {
        Id = product.Id;
        CreatedDate = product.CreatedDate;
        UpdatedDate = product.UpdatedDate;
        IsDeleted = product.IsDeleted;
        Name = product.Name;
        ImageSrc = product.ImageSrc;
        ManufacturedDate = product.ManufacturedDate;
        ExpireDate = product.ExpireDate;
        Price = product.Price;
        CategoryId = product.CategoryId;
        CompanyId = product.CompanyId;
    }

    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
    public string Name { get; set; }
    public string? ImageSrc { get; set; }
    public DateTime ManufacturedDate { get; set; }
    public int CategoryId { get; set; }
    public int CompanyId { get; set; }
    public DateTime ExpireDate { get; set; }
    public decimal Price { get; set; }
}
