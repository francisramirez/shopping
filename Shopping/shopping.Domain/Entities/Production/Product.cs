using shopping.Domain.Core;

namespace shopping.Domain.Entities.Production
{
    public class Product : BaseEntity
    {
        public int productid { get; set; }
        public int supplierid { get; set; }
        public int categoryid { get; set; }
        public decimal unitprice { get; set; }
        public bool discontinued { get; set; }
      
    }
}
