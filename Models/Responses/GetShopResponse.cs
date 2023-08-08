using EfCore.Entities;

namespace EfCore.Models.Responses;

public class GetShopResponse
{
    

    public GetShopResponse(Shop entity)
    {
        Id = entity.Id;
        CreatedDate = entity.CreatedDate;
        UpdatedDate = entity.UpdatedDate;
        IsActive = entity.IsActive;
        Name = entity.Name;
        Adrress = entity.Adrress;
        Phone = entity.Phone;
        UpperId = entity.UpperId;
        Branches = entity.Branches?.Select(e=>new GetShopResponse(e));
    }

    public int Id { get; set; }
    public  DateTime CreatedDate { get; set; } 
    public  DateTime? UpdatedDate { get; set; }
    public bool IsActive { get; set; }
    public string? Name { get; set; }
    public string? Adrress { get; set; }
    public string? Phone { get; set; } 
    public int? UpperId { get; set; }
    public IEnumerable<GetShopResponse>? Branches { get; set; }
}
