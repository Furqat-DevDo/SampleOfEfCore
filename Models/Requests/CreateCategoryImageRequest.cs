using System.Diagnostics.CodeAnalysis;

namespace EfCore.Models.Requests;

public class CreateCategoryImageRequest
{
    [NotNull]
    public required IFormFile CategoryFile { get; set; }
}
