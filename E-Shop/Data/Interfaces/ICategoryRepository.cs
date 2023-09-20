using E_Shop.Data.Models;

namespace E_Shop.Data.Interfaces
{
	public interface ICategoryRepository
	{
		IEnumerable<Category> GetCategories { get; }
	}
}
