using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Models.Requests;

public class CreateStorageRequest
{
    public required string Name { get; set; }
    public required string Adrress { get; set; }
    public List<int>? ProductIds { get; set; }
}
