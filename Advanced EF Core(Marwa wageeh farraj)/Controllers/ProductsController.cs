using Advanced_EF_Core_Marwa_wageeh_farraj_.DbContext;
using Advanced_EF_Core_Marwa_wageeh_farraj_.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Advanced_EF_Core_Marwa_wageeh_farraj_.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		
			private readonly ApplicationDbContext _context;

			public ProductsController(ApplicationDbContext context)
			{
				_context = context;
			}

			// GET: api/products?pageNumber=1&pageSize=10
			[HttpGet]
			public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(
				int pageNumber = 1,
				int pageSize = 10)
			{
				if (pageNumber < 1 || pageSize < 1)
					return BadRequest("Page number and page size must be positive.");

				pageSize = Math.Min(pageSize, 100);

				var products = await _context.Products
					.AsNoTracking()
					.OrderBy(p => p.Id)
					.Skip((pageNumber - 1) * pageSize)
					.Take(pageSize)
					.Select(p => new ProductDto
					{
						Id = p.Id,
						Name = p.Name,
						Price = p.Price,
						Description = p.Description,
						Stock = p.Stock,
						CategoryId = p.CategoryId,
						CategoryName = p.Category != null
							? p.Category.Name
							: null,
						RowVersion = p.RowVersion
					})
					.ToListAsync();

				return Ok(products);
			}

			// PUT: api/products/1
			[HttpPut("{id}")]
			public async Task<IActionResult> UpdateProduct(
				int id,
				UpdateProductDto dto)
			{
				var product = await _context.Products
					.FirstOrDefaultAsync(p => p.Id == id);

				if (product == null)
					return NotFound();

				bool categoryExists = await _context.Categories
					.AnyAsync(c => c.Id == dto.CategoryId);

				if (!categoryExists)
					return BadRequest("Category does not exist.");

				// Use the version sent by the client
				// to detect stale updates.
				_context.Entry(product)
					.Property(p => p.RowVersion)
					.OriginalValue = dto.RowVersion;

				// Update only permitted properties.
				product.Name = dto.Name;
				product.Price = dto.Price;
				product.Description = dto.Description;
				product.Stock = dto.Stock;
				product.CategoryId = dto.CategoryId;

				try
				{
					await _context.SaveChangesAsync();
					return NoContent();
				}
				catch (DbUpdateConcurrencyException)
				{
					return Conflict(
						"The product was changed by another user. Reload it and try again.");
				}
			}

			// DELETE: api/products/1
			// Soft delete: do not physically remove the row.
			[HttpDelete("{id}")]
			public async Task<IActionResult> DeleteProduct(int id)
			{
				var product = await _context.Products
					.FirstOrDefaultAsync(p => p.Id == id);

				if (product == null)
					return NotFound();

				product.IsDeleted = true;

				try
				{
					await _context.SaveChangesAsync();
					return NoContent();
				}
				catch (DbUpdateConcurrencyException)
				{
					return Conflict(
						"The product was changed by another user. Reload it and try again.");
				}
			}
		}
	}

