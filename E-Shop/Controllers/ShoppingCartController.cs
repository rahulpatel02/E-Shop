using E_Shop.Data.Interfaces;
using E_Shop.Data.Models;
using E_Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartController(IProductRepository productRepository,ShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
            
        }
        public ActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart=_shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
            };
            return View(sCVM);

        }
        public  RedirectToActionResult AddToShoppingCart(int productId)
        {
            var selectProduct=_productRepository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (selectProduct != null)
            {
                _shoppingCart.AddToCart(selectProduct,1);
            }
            return RedirectToAction("Index","Home");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var selectProduct = _productRepository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (selectProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectProduct);
            }
            return RedirectToAction("Index");
        }

       

    }
}
