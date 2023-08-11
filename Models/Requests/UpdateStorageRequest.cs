using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Models.Requests;

public class UpdateStorageRequest
{
    public required string Adrress { get; set; }
    public required string Name { get; set; }
    public List<int>? ProductIds { get; set; }
}
