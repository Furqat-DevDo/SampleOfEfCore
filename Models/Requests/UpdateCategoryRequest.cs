using EfCore.Entities;

namespace EfCore.Models.Requests
{
    public class UpdateCategoryRequest
    {
        
        public string Name { get; set; } = string.Empty;
        public int? UpperId { get; set; }
        public Guid? ImageID { get; set; }
 
    }
}
