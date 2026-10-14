namespace Advanced_EF_Core_Marwa_wageeh_farraj_.Models
{
	public class Category
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public ICollection<Product> Products { get; set; }
			= new List<Product>();
	}
}
