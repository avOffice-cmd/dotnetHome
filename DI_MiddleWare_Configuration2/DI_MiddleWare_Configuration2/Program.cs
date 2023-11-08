
using DI_MiddleWare_Configuration2.Context;
using DI_MiddleWare_Configuration2.DataAcessLayer;
using DI_MiddleWare_Configuration2.Helper;
using DI_MiddleWare_Configuration2.MiddleWare;
using DI_MiddleWare_Configuration2.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace DI_MiddleWare_Configuration2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();


            //==========//  as a service i registered my middleWare   //==========//

            builder.Services.AddTransient<AuthMiddleware>();


            // DB context config
            builder.Services.AddDbContext<MyDbContext>(options =>
            options.
            UseSqlServer(builder.Configuration.GetConnectionString("connStr")));



            // builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IcustomerRepository, CustomerRepository>();

            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IorderRepository, OrderRepository>();

            // IOptions
            // IOptions
            builder.Services.Configure<Messages>
                (builder.Configuration.GetSection("a:b:c:d"));
            

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(
            c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DI_Middleware_Configuration2", Version = "V1" });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                c.CustomSchemaIds(x => x.FullName);
            });



            builder.Services.AddTransient<CustomMiddleWare>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }



            app.UseMiddleware<AuthMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();




            //app.UseMiddleware<CustomMiddleWare>();
            //app.Map("/m2", appMap =>
            //{
            //    appMap.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("Hello from 2nd app.Map()");
            //    });
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Before Invoke from 1st app.Use()\n");
            //    await next();
            //    await context.Response.WriteAsync("After Invoke from 1st app.Use()\n");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Before Invoke from 2nd app.Use()\n");
            //    await next();
            //    await context.Response.WriteAsync("After Invoke from 2nd app.Use()\n");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from 1st app.Run()\n");
            //});

            //// the following will never be executed    
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello from 2nd app.Run()\n");
            //});


            app.Run();
        }
    }
}