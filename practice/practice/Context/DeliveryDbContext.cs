using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using practice.Model;

namespace practice.Context
{
    public class DeliveryDBContext : DbContext
    {

        public DeliveryDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
