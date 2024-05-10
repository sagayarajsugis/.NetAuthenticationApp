namespace AuthenticationApplication.Models
{
    public class ProductDto  : DbEntity
    {
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Number { get; set; }
        public bool Expired { get; set; }
        public DateTime  Packed {  get; set; }  

        public SubProduct subProduct { get; set; } = new SubProduct();
    }

    public class SubProduct
    {
        public string SubProductName { get; set; } = null!;
        public int UniqueNumber { get; set; }

        public int Price { get; set; }  
    }
}
