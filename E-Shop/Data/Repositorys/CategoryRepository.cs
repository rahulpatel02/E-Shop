using E_Shop.Data.Interfaces;
using E_Shop.Data.Models;

namespace E_Shop.Data.Repositorys
{
	public class CategoryRepository : ICategoryRepository
	{
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

		public IEnumerable<Category> GetCategories => _context.Categories;
	}
}
