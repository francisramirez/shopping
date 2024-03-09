namespace shopping.Application.Models.Product
{
    public class ProductGetModel
    {
        public int Productid { get; set; }
        public string? Productname { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Discontinued { get; set; }
        public int SupplierId { get; set; }
        public string? SupplerName { get; set; }

    }
}
