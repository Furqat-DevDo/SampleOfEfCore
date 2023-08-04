namespace EfCore.Models.Requests;

public class UpdateShopRequest
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public string Phone { get; set; } = null!;
    public int? UpperId { get; set; }
}
