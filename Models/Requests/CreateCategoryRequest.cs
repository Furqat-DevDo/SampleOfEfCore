using EfCore.Attributes;

namespace EfCore.Models.Requests
{
    public class CreateCategoryRequest
    {
        [StringValidator(MinLength = 5,MaxLength =15)]
        public string Name { get; set; } = string.Empty;
        public int? UpperId { get; set; }
        public Guid? ImageID { get; set; }
       
    }
}
