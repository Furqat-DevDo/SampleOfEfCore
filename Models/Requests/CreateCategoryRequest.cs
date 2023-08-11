namespace EfCore.Models.Requests
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; } = string.Empty;
        public int? UpperId { get; set; }

    }
}
