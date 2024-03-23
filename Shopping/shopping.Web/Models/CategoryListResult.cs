using shopping.Application.Models.Category;

namespace shopping.Web.Models
{
    public class CategoryListResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<CategoryGetModel> data { get; set; }
    }
}
