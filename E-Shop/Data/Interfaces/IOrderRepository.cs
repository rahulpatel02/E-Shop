using E_Shop.Data.Models;

namespace E_Shop.Data.Interfaces
{
	public interface IOrderRepository
	{
		void CreateOrder (Order order);
	}
}
