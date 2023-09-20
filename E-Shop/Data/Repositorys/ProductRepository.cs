using E_Shop.Data.Interfaces;
using E_Shop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Data.Repositorys
{
	public class ProductRepository:IProductRepository
	{
          private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
            
        }

		public IEnumerable<Product> Products => _context.Products.Include(c =>c.Category);

		public Product GetProductById(int productId) =>_context.Products.FirstOrDefault(p => p.ProductId == productId);
		
	}
}
