using shopping.Application.Models.Category;

namespace shopping.Web.Models
{
    public class CategoryDetailView
    {
        public bool success { get; set; }
        public string? message { get; set; }
        public CategoryGetModel? data { get; set; }
    }
}
