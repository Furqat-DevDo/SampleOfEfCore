namespace EfCore.Models.Responses;

public class GetProductImageResponse
{
    public required string FileSrc { get; set; }
    public int ProductId { get; set; }
    public Guid FileId { get; set; }
}
