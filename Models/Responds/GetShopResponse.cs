using System.ComponentModel;

namespace EfCore.Models.Responds;

public class GetShopResponse
{
    public virtual int Id { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime? UpdateDate { get; set; }
    public bool IsDeleted { get; set; }
    public virtual bool IsActive { get; set; }
    public List<GetShopResponse>? Branches { get; set; }
}