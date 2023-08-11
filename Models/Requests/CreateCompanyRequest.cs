using System.ComponentModel.DataAnnotations;
using EfCore.Attributes;

namespace EfCore.Models.Requests;

public class CreateCompanyRequest
{
    [StringValidation]
    public required string Name { get; set; }

    [DataType(DataType.Date)]
    public DateTime? ClosedDate { get; set; }

    public int? UpperId { get; set; }
}