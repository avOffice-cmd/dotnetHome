
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using practice.Context;
using practice.DataAcessLayer;
using practice.Services;
using System.Reflection;

namespace practice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();


            // Code for dependency injection of context into the Repository
            builder.Services.AddDbContext<DeliveryDBContext>(options =>
            options.
            UseSqlServer(builder.Configuration.GetConnectionString("localConnString")), ServiceLifetime.Transient);
            //GetConnectionString --> repository me context ko inject kar raha hai


            // Registering for other dependencies in the DI container
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICustomerRepisitory, CustomerRepository>();
          


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(
          c =>
          {
              c.SwaggerDoc("v1", new OpenApiInfo { Title = "practice", Version = "V1" });
              var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
              c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
              c.CustomSchemaIds(x => x.FullName);
          });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}