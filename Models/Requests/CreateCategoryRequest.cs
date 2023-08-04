using EfCore.Entities;

namespace EfCore.Models.Requests
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; } = string.Empty;
        public int? UpperId { get; set; }
        public Category? Upper { get; set; }
        public Guid? ImageID { get; set; }
       
    }
}
