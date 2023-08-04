using EfCore.Entities;

namespace EfCore.Models.Responses
{
    public class GetCategoryResponse
    {
        
        public GetCategoryResponse(Category entitie)
        {
            //Id = entitie.Id;
            Name = entitie.Name;
            UpperId = entitie.UpperId;
            ImageId = entitie.ImageId;
            Upper = entitie.Upper;

        }

        //public int Id { get; set; }
        public string? Name { get; set; }
        public int? UpperId { get; set; }
        public Guid? ImageId { get; set; }
        public Category? Upper { get; set; }

    }
}
