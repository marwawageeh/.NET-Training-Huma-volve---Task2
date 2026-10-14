using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Advanced_EF_Core_Marwa_wageeh_farraj_.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;

		[Column(TypeName = "decimal(18,2)")]
		public decimal Price { get; set; }

		public string? Description { get; set; }

		public int Stock { get; set; }

		public int CategoryId { get; set; }

		public Category? Category { get; set; }

		public bool IsDeleted { get; set; } = false;

		[Timestamp]
		public byte[] RowVersion { get; set; } = [];
	}
}
