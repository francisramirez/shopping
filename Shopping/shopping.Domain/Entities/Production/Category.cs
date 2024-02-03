

using shopping.Domain.Core;

namespace shopping.Domain.Entities.Production
{
    public class Category : BaseEntity
    {
        public int categoryid { get; set; }
        public string? categoryname { get; set; }
        public string? description { get; set; }
       
    }
}
