using EfCore.Entities;
using EfCore.Attributes

namespace EfCore.Models.Requests
{
    public class UpdateCategoryRequest
    {
        [StringValidator(minLength:3,maxLength:50)]
        public string Name { get; set; } = string.Empty;
        public int? UpperId { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
