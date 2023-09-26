using E_Shop.Data.Interfaces;
using E_Shop.Data.Models;

namespace E_Shop.Data.Repositorys
{
	public class OrderRepository:IOrderRepository
	{
		private readonly AppDbContext	_context;
		private readonly ShoppingCart _shoppingCart;
        public OrderRepository( AppDbContext appDbContext,ShoppingCart shoppingCart)
        {
			_context = appDbContext;
			_shoppingCart = shoppingCart;
            
        }

		public void CreateOrder(Order order)
		{
			
			order.OrderPlaced=DateTime.Now;
			

			_context.Orders.Add(order);

            _context.SaveChanges();

            var shoppingCartItems=_shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
				var orderDetail=new OrderDetail()
				{
					Amount=item.Amount,
					ProductId = item.Product.ProductId,
					OrderId=order.OrderId,
					Price=item.Product.Price,
				};

				_context.OrderDetails.Add(orderDetail);
  
            }
			_context.SaveChanges();
        }
	}
}
