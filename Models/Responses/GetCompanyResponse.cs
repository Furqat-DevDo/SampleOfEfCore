namespace EfCore.Models.Responses;

public class GetCompanyResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public required string Name { get; set; }
    public DateTime? ClosedDate { get; set; }
    public int? UpperId { get; set; }
    public List<GetCompanyResponse>? Branches { get; set; }
}