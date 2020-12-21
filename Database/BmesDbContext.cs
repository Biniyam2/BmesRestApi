using Microsoft.EntityFrameworkCore;
using BmesRestApi.Models.Cart;


namespace BmesRestApi.Database
{
    public class BmesDbContext : DbContext
    {
        public BmesDbContext(DbContextOptions<BmesDbContext> options) : base(options)
        { }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Models.Product.Product> Products { get; set; }
        public DbSet<Models.Product.Category> Categories { get; set; }
        public DbSet<Models.Product.Brand> Brands { get; set; }
        public DbSet<Models.Addresses.Address> Addresses { get; set; }
        public DbSet<Models.Shared.Person> people { get; set; }
        public DbSet<Models.Customer.Customer> Customers { get; set; }
        public DbSet<Models.Order.Order> Orders { get; set; }
        public DbSet<Models.Order.OrderItem> OrderItems{ get; set; }



    }
}
