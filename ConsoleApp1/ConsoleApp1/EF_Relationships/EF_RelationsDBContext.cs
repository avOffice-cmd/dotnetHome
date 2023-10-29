using ConsoleApp1.EF_Relationships.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.EF_Relationships
{
    internal class EF_RelationsDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OfficeFloor> OfficeFloors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                Server=DESKTOP-KPI5JP5\SQLEXPRESS;
                Database=EF_RelationsDB;
                Trusted_Connection=true;
                TrustServerCertificate=true;
                MultipleActiveResultSets=true; ");
        }
    }
}
