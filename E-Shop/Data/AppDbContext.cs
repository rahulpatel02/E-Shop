﻿
using E_Shop.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Shop.Data
{
	public class AppDbContext : IdentityDbContext<User>
	{
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }

       public  DbSet<Product>Products { get; set; }
       public  DbSet<Category>Categories { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
