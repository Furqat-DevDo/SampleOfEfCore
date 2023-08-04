using EfCore.Entities;

namespace EfCore.Models.Responses;

public class GetStorageResponse
{
    public GetStorageResponse(Storage entity)
    {
        Id = entity.Id;
        CreatedDate = entity.CreatedDate;
        UpdatedDate = entity.UpdatedDate;
        IsDeleted = entity.IsDeleted;
        Name = entity.Name;
        Adrress = entity.Address;
        //ProductIds = entity.ProductIds?.Select(e=>new GetStorageResponse(e));
    }

    public int Id { get; set; }
    public  DateTime CreatedDate { get; set; } 
    public  DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
    public string? Name { get; set; }
    public string? Adrress { get; set; }
    public IEnumerable<GetStorageResponse>? ProductIds { get; set; }
    public int E { get; }
}
