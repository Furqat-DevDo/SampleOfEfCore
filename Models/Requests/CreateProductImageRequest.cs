using System.Diagnostics.CodeAnalysis;

namespace EfCore.Models.Requests;

public class CreateProductImageRequest
{
    [NotNull]
    public required IFormFile ProductFile { get; set; }
}
