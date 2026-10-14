namespace Advanced_EF_Core_Marwa_wageeh_farraj_.DTOs
{
	public class ProductDto
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public decimal Price { get; set; }

		public string? Description { get; set; }

		public int Stock { get; set; }

		public int CategoryId { get; set; }

		public string? CategoryName { get; set; }

		public byte[] RowVersion { get; set; } = [];
	}
}
