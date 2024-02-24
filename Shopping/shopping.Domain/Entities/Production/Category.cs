

using shopping.Domain.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping.Domain.Entities.Production
{

    [Table("Categories", Schema = "Production")]
    public class Category : BaseEntity
    {

        [Key]
        public int categoryid { get; set; }

      
        public string? categoryname { get; set; }

        
        public string? description { get; set; }
       
    }
}
