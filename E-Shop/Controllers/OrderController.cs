using Microsoft.AspNetCore;
using E_Shop.Data.Interfaces;
using E_Shop.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderRepository _orderRepository;
		private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository,ShoppingCart shoppingCart	)
        {
			_orderRepository = orderRepository;
			_shoppingCart = shoppingCart;
            
        }
		public IActionResult Checkout()
		{
			return View();
		}

            [HttpPost]
        public IActionResult Checkout(Order order)
		{
			var items = _shoppingCart.GetShoppingCartItems();
			_shoppingCart.ShoppingCartItems = items;
			if (_shoppingCart.ShoppingCartItems.Count == 0)
			{
				ModelState.AddModelError("", "Your cart is empty, add some products first");

			}
            if (ModelState.IsValid)
            {
				_orderRepository.CreateOrder(order);
				_shoppingCart.ClearCart();
				return RedirectToAction("CheckoutComplete");
			}
			return View(order);
		}
		public IActionResult CheckoutComplete() 
		{
			ViewBag.CheckoutCompleteMessage = "Thanks for your order!:) ";
			return View();
		}

		public IActionResult ViewOrder()
		{
			var result=_orderRepository.GetUserOrder();
			return View(result);
		}
		 public   IActionResult OrderDetails(int orderId)
		{
			var orderDetails =  _orderRepository.GetOrderDetails(orderId);
			return View(orderDetails);
		}

		public IActionResult CancleOrder(int orderId)
		{
			_orderRepository.CancelOrder(orderId);
			return RedirectToAction("ViewOrder");

		}
	}
}
