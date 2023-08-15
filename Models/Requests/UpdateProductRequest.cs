using EfCore.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EfCore.Models.Requests;

public class UpdateProductRequest
{
    [StringValidator(minLength: 1, maxLength: 30, ErrorMessage = "Product name")]
    public required string Name { get; set; }
    public required int CategoryId { get; set; }
    public required int CompanyId { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime ManufacturedDate { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime ExpireDate { get; set; }

    [PriceValidator]
    public decimal Price { get; set; }
}
