using EfCore.Attributes;

namespace EfCore.Models.Requests;

public class UpdateShopRequest
{
    [StringValidator(minLength: 1, maxLength: 30, ErrorMessage = "Shop name")]
    public required string Name { get; set; }

    [StringValidator(minLength: 1, maxLength: 100, ErrorMessage = "Shop address")]
    public required string Adrress { get; set; }

    [PhoneNumberValidator]
    public string Phone { get; set; } = null!;
    public int? UpperId { get; set; }
}
