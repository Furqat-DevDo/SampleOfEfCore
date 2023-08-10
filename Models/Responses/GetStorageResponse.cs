namespace EfCore.Models.Responses;

public class GetStorageResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public required string Name { get; set; }
    public required string Adress { get; set; }
    public List<int>? ProductIds { get; set; }
}
