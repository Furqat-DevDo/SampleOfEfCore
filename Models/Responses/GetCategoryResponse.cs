using EfCore.Entities;

namespace EfCore.Models.Responses
{
    public class GetCategoryResponse
    {
        
        public GetCategoryResponse(Category entitie)
        {
            Id = entitie.Id;
            Name = entitie.Name;
            UpperId = entitie.UpperId;
            ImageId = entitie.ImageId;
            IsActive = entitie.IsDeleted;
            CreatedDate= entitie.CreatedDate;
            UpdatedDate = entitie.UpdatedDate;

        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? UpperId { get; set; }
        public Guid? ImageId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }


    }
}
