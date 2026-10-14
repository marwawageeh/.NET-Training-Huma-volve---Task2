using System.ComponentModel.DataAnnotations;

namespace Advanced_EF_Core_Marwa_wageeh_farraj_.DTOs
{
	public class UpdateProductDto
	{
		[Required]
		public string Name { get; set; } = string.Empty;

		[Range(0, double.MaxValue)]
		public decimal Price { get; set; }

		public string? Description { get; set; }

		[Range(0, int.MaxValue)]
		public int Stock { get; set; }

		[Range(1, int.MaxValue)]
		public int CategoryId { get; set; }

		[Required]
		public byte[] RowVersion { get; set; } = [];
	}
}
