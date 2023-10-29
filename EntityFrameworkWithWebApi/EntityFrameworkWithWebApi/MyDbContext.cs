using EntityFrameworkWithWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkWithWebApi
{
    public class MyDbContext : DbContext
    {
        public DbSet<EmployeeModel> Employees { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                Server=DESKTOP-KPI5JP5\SQLEXPRESS;
                Database=EF_MyDBWebAPI;
                Trusted_Connection=true;
                TrustServerCertificate=true;
                MultipleActiveResultSets=true; ");
        }

    }
}
