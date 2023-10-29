using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.EF_Crud_joins
{
    internal class MyDbContext : DbContext
    {
        public DbSet<EmployeeModel> Employeess { get; set; }
        public DbSet<Boss> Bossess { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                Server=DESKTOP-KPI5JP5\SQLEXPRESS;
                Database=EF_MyDB2;
                Trusted_Connection=true;
                TrustServerCertificate=true;
                MultipleActiveResultSets=true; ");
        }

    }

}
