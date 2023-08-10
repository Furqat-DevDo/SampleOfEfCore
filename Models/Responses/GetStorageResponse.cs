namespace EfCore.Models.Responses;

public class GetStorageResponse
{
    public required string Name { get; set; }
    public required string Adress { get; set; }
    public List<int> ProductIds { get; set; }
}
