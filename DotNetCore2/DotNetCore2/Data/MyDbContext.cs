using DotNetCore2.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore2.Data
{
    public class MyDbContext : DbContext
    {
        // call base class
        //public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { 

        //}
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }


        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }
    }
}
