using DI_MiddleWare_Configuration2.Models;
using Microsoft.EntityFrameworkCore;

namespace DI_MiddleWare_Configuration2.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(builder =>
            {
                builder.HasKey(c => c.Id);
                builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
                builder.Property(c => c.PhoneNumber).HasMaxLength(15).IsRequired();
                builder.Property(c => c.Email).HasMaxLength(50).IsRequired();

                builder
                .HasMany<Order>(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId).IsRequired();

            });


            modelBuilder.Entity<Order>(builder =>
            {

                builder.HasKey(o => o.Id);
                builder.Property(o => o.InvoiceId).HasMaxLength(50).IsRequired(true);
                builder.Property(o => o.Total_Amt).IsRequired(true);
                builder.Property(o => o.OrderDate).IsRequired(true);
                builder.Property(o => o.DeliveryCity).HasMaxLength(50).IsRequired(true);
                builder.Property(o => o.OrderStatus).HasMaxLength(50).IsRequired(true);
                builder.Property(o => o.DeliveryDate).IsRequired(false);


            });



        }
    }
}
