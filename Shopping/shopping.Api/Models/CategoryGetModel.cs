using shopping.Api.Dtos.Category;

namespace shopping.Api.Models
{
    public class CategoryGetModel 
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
