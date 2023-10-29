using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.EF_FluentApi
{
    public class EF_MyFluentAPIContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                Server=DESKTOP-KPI5JP5\SQLEXPRESS;
                Database=EF_MyFluentAPI;
                Trusted_Connection=true;
                TrustServerCertificate=true;
                MultipleActiveResultSets=true; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. method that change the table name
            modelBuilder.Entity<Employee>().ToTable("Users");

            // 2. Defines the primary key for an entity/table.
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);


            // 3. Adding contraints to column 'FullName'
            modelBuilder.Entity<Employee>()
                            .Property(e => e.FullName)
                            .HasColumnName("Name")
                            .IsRequired()
                            .HasMaxLength(100)
                            .HasDefaultValue("Guest");
        }
    }
}
