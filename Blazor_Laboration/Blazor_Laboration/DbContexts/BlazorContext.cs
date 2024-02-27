using Blazor_Laboration.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Laboration.DbContexts
{
    public class BlazorContext(DbContextOptions<BlazorContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
