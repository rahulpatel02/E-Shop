using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Data.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _context;

        public ShoppingCart(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            //  string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            string cartId = "1";
            session.SetString(cartId, cartId); 
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Product product, int amount)
        {
            var shoppingCartItem=_context.ShoppingCartItems.SingleOrDefault(
                s=>s.Product.ProductId== product.ProductId && s.ShoppingCartId.Equals( ShoppingCartId));
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges() ;
        }
        //Remove from Cart
        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
                s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount= shoppingCartItem.Amount;

                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            
            _context.SaveChanges();
            return localAmount;
        }
        //Get All ShopinfCartItems

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems=
                _context.ShoppingCartItems.Where(c=>c.ShoppingCartId==ShoppingCartId)
                .Include(s=>s.Product)
                .ToList()); 
        }

        //use for Checkout 
        public void ClearCart()
        {
            var cartItems=_context.ShoppingCartItems.Where(cart=>cart.ShoppingCartId==ShoppingCartId);
            _context.ShoppingCartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total=_context.ShoppingCartItems.Where(c =>c.ShoppingCartId== ShoppingCartId)
                .Select(c=> c.Product.Price*c.Amount).Sum();
            return total;
        }
    }
}
