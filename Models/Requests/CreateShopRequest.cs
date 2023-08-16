using EfCore.Attributes;

namespace EfCore.Models.Requests;

public class CreateShopRequest
{
    [StringValidator(minLength: 1, maxLength: 40, ErrorMessage = "Shop name")]
    public required string Name { get; set; }
    [StringValidator(minLength: 5, maxLength: 100, ErrorMessage = "Shop address")]
    public required string Adrress { get; set; }

    [PhoneNumberValidator]
    public string Phone { get; set; } = null!;
    public int? UpperId { get; set; }
}
