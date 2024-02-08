using System.ComponentModel.DataAnnotations;

namespace G5Inventory.Models
{
    public class ProductModel
    {
        public int IdProduct { get; set; }
        [Required]
        public string ProductName { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public int IdCategory { get; set; }
		[Required]
		public int IdProvider { get; set; }
		[Required]
		public string Expiration { get; set; }
		[Required]
		public int Stock { get; set; }
    }
}
