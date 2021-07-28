using Microsoft.EntityFrameworkCore;
using Restaurant.OrderService.Domain;

namespace Restaurant.OrderService.Infrastructure.DataAccess.Context
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
        }
    }
}
