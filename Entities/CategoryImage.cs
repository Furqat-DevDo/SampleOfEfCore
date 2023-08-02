using EfCore.Entities.Abstractions;

namespace EfCore.Entities;

public class CategoryImage : BaseFile
{
    public required int CategoryId { get; set; }
}
