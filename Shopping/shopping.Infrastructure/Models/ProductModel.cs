

namespace shopping.Infrastructure.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public int CategoryId { get; set; }
        public string? CatetoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }


    }
}
