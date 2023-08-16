using EfCore.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EfCore.Models.Requests;

public class UpdateCompanyRequest
{
    [StringValidator(minLength: 1, maxLength: 30, ErrorMessage = "Company name")]
    public required string Name { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? ClosedDate { get; set; }
    public int? UpperId { get; set; }
}