//using DotNetCore2.Data;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

//namespace DotNetCore2
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddControllersWithViews(); // Add MVC services
//            // Add other services as needed

//            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
//        }

     

//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage(); // Show detailed error pages in development
//                //app.UseDatabaseErrorPage();
               
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error"); // Configure error handling for production
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllerRoute(
//                    name: "default",
//                    pattern: "{controller=Home}/{action=Index}/{id?}");
//                // Configure your routes as needed
//            });
//        }
//    }
//}

