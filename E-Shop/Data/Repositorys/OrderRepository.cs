using E_Shop.Data.Interfaces;
using E_Shop.Data.Models;
using E_Shop.Helpers;
using E_Shop.ViewModels;

namespace E_Shop.Data.Repositorys
{
	public class OrderRepository:IOrderRepository
	{
		private readonly AppDbContext	_context;
		private readonly ShoppingCart _shoppingCart;
        private readonly IUserService _userService;
        public OrderRepository( AppDbContext appDbContext,ShoppingCart shoppingCart,IUserService userService)
        {

              _userService= userService;
			_context = appDbContext;
			_shoppingCart = shoppingCart;
            
        }

		public void CreateOrder(Order order)
		{
			
			order.OrderPlaced=DateTime.Now;
			

			_context.Orders.Add(order);

            _context.SaveChanges();
          


            var shoppingCartItems =_shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    OrderId = order.OrderId,
                    ProductId = item.Product.ProductId,
                    Amount = item.Amount,
                    Price = item.Product.Price,
                    CustomerId = _userService.GetUserId()
                };

				_context.OrderDetails.Add(orderDetail);
  
            }
			_context.SaveChanges();
        }

        public IEnumerable<OrderViewModel> GetUserOrder()
        {
            var result= _context.OrderDetails.OrderByDescending( e=>e.CustomerId==_userService.GetUserId()).ToList();

                  List<OrderViewModel> list= new List<OrderViewModel>();
            if (result?.Any() != null)
            {
                foreach (var item in result)
                {
                    var productName=_context.Products.FirstOrDefault(p=>p.ProductId==item.ProductId);
                    list.Add(new OrderViewModel()
                    {
                       
                        OrderId = item.OrderId,
                        ProductName = productName.Name,
                        Qty = item.Amount,
                        Price = item.Product.Price,

                    });
                }
            }
            return list;
            
        }
    }
}
