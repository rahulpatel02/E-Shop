using E_Shop.Data.Models;
using E_Shop.ViewModels;

namespace E_Shop.Data.Interfaces
{
	public interface IOrderRepository
	{
		void CreateOrder (Order order);
 
		 IEnumerable<OrderViewModel> GetUserOrder ();

		 void CancelOrder (int orderId);

		OrderDetailsViewModel GetOrderDetails(int orderId);


	}
}
