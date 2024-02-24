using shopping.Domain.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping.Domain.Entities.Production
{

    [Table("Products", Schema = "Production")]
    public class Product : BaseEntity
    {
        public int productid { get; set; }
        public string? productname { get; set; }
        public int supplierid { get; set; }
        public int categoryid { get; set; }
        public decimal unitprice { get; set; }
        public bool discontinued { get; set; }
      
    }
}
