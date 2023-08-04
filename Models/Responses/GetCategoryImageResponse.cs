using EfCore.Entities;
namespace EfCore.Models.Responses
{
    public class GetCategoryImageResponse
    {
        public GetCategoryImageResponse(CategoryImage entity)
        {
            CategoryId = entity.CategoryId;
            CreatedDate = entity.CreatedDate;
            UpdatedDate = entity.UpdatedDate;
            IsDeleted = entity.IsDeleted;
        }

      
        public int? CategoryId { get; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        
        public IEnumerable<GetCategoryImageResponse>? Branches { get; set; }
    }
}
