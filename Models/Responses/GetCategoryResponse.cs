using EfCore.Entities;

namespace EfCore.Models.Responses
{
    public class GetCategoryResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? UpperId { get; set; }
        public Guid? ImageId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }


    }
}
