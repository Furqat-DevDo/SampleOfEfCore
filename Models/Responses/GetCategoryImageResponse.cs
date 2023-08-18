namespace EfCore.Models.Responses;

public class GetCategoryImageResponse
{
    public required string FileSrc { get; set; }
    public int CategoryId { get; set; }
    public Guid FileId { get; set; }
}
