namespace EfCore.Models.Responses;

public class GetShopResponse
{
    public int Id { get; set; }
    public  DateTime CreatedDate { get; set; } 
    public  DateTime? UpdatedDate { get; set; }
    public bool IsActive { get; set; }
    public string? Name { get; set; }
    public string? Adrress { get; set; }
    public string? Phone { get; set; } 
    public int? UpperId { get; set; }
    public IEnumerable<GetShopResponse>? Branches { get; set; }
}
