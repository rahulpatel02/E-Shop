
using E_Shop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }

       public  DbSet<Product>Products { get; set; }
       public  DbSet<Category>Categories { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
