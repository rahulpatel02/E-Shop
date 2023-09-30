using E_Shop.Data.Interfaces;
using E_Shop.Data.Models;
using E_Shop.Helpers;
using E_Shop.Migrations;
using E_Shop.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

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
			order.OrderTotal=_shoppingCart.GetShoppingCartTotal();

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
             string userId=string.Empty;
            userId = _userService.GetUserId();
            var result= _context.OrderDetails.Where( e=>e.CustomerId==userId);

                  List<OrderViewModel> list= new List<OrderViewModel>();
            if (result?.Any() != null)
            {
                var productName = _context.Products.ToList();
                foreach (var item in result)
                {
                    string name = string.Empty;
                    foreach(var product in productName)
                    {
                        if(product.ProductId == item.ProductId)
                        {
                            name= product.Name;
                            break;
                        }
                    }
                    
                    list.Add(new OrderViewModel()
                    {
                       
                        OrderId = item.OrderId,
                        ProductName = name,
                        Qty = item.Amount,
                        Price = item.Product.Price,

                    });
                }
            }
            return list;
            
        }
		public void CancelOrder(int orderId)
		{
          var orderItem=  _context.OrderDetails.Where(odr => odr.OrderId == orderId);
			_context.OrderDetails.RemoveRange(orderItem);
			_context.SaveChanges();
		}

        public  OrderDetailsViewModel GetOrderDetails(int orderId)
        {
              
            Order userOrderInfo = _context.Orders.FirstOrDefault(odr => odr.OrderId == orderId);

            var ordersItems = _context.OrderDetails.Where(order => order.OrderId == orderId);

              var produtItems=_context.Products.ToList();
       
           
            var list = new List<ProductNameAndOrdersMapper>();
            foreach (var item in ordersItems)
            {
                string Name =string.Empty;
                foreach (var p in produtItems )
                {
                    if (item.ProductId == p.ProductId)
                    {
                        Name = p.Name;
                        break;
                    }
                }
                list.Add(new ProductNameAndOrdersMapper()
                {
                    OrderId = item.OrderId,
                    ProductName =Name,
                    Qty = item.Amount,
                    UnitPrice = item.Price,
                    TotalAmountPerUnit = item.Price * item.Amount,
                });
            }
            var orderDetailsViewModel = new OrderDetailsViewModel
            {
                userOrderInfo = userOrderInfo,
                ProductNameAndOrdersMapper = list
            };
            return orderDetailsViewModel;
		}

        private async Task< string> GetProductName(int productId)
        {
			var productDetails = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            return productDetails.Name;
		}
	}
}
