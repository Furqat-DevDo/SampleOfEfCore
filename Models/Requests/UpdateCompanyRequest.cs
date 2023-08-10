namespace EfCore.Models.Requests;

public class UpdateCompanyRequest
{
    public required string Name { get; set; }
    public DateTime? ClosedDate { get; set; }
    public int? UpperId { get; set; }
}