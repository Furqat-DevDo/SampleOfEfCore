namespace EfCore.Models.Responses;

public class GetShopResponse
{
    public int Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? UpdatedTime { get; set; }
    public bool IsDeleted { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public int? UpperId { get; set; }
    public List<GetShopResponse>? Branches { get; set; }

}
