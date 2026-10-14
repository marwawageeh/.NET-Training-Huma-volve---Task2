
using Advanced_EF_Core_Marwa_wageeh_farraj_.Models;
using Microsoft.EntityFrameworkCore;

namespace Advanced_EF_Core_Marwa_wageeh_farraj_.DbContext
{
	public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public ApplicationDbContext(
			DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Product> Products => Set<Product>();

		public DbSet<Category> Categories => Set<Category>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Product>()
				.HasIndex(p => p.Name);

			modelBuilder.Entity<Product>()
				.HasQueryFilter(p => !p.IsDeleted);
		}
	}
}
