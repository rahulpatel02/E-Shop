using E_Shop.Data.Models;

namespace E_Shop.Data.Interfaces
{
	public interface IProductRepository
	{
		IEnumerable<Product> Products { get; }
		Product GetProductById(int productId);
	}
}
