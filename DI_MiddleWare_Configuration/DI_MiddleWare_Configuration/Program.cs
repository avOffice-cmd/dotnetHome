using DI_MiddleWare_Configuration.Context;
using DI_MiddleWare_Configuration.DataAccessLayer;
using DI_MiddleWare_Configuration.Extensions;
using DI_MiddleWare_Configuration.Helper;
using DI_MiddleWare_Configuration.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// DB context config
builder.Services.AddDbContext<OrderContext>(options =>
options.
UseSqlServer(builder.Configuration.GetConnectionString("connStr")));

// Registering all dependencies

builder.Services.AddTransient<ITransientUniqueKeyProvider>(provider => new UniqueKeyProvider(Guid.NewGuid()));
builder.Services.AddScoped<IScopedUniqueKeyProvider>(provider => new UniqueKeyProvider(Guid.NewGuid()));
builder.Services.AddSingleton<ISingletonUniqueKeyProvider>(provider => new UniqueKeyProvider(Guid.NewGuid()));
builder.Services.AddTransient<ITestService, TestService>();


builder.Services
    .AddScoped<IOrderRepository, OrderRepository>();

// IOptions
builder.Services.Configure<Messages>(builder.Configuration.GetSection("Messages"));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "DI_MiddleWare_Configuration", Version = "V1" });
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        c.CustomSchemaIds(x => x.FullName);
    });

// Read - https://blog.maartenballiauw.be/post/2022/09/26/aspnet-core-rate-limiting-middleware.html

// In .NET 7, use below
builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = 
    PartitionedRateLimiter.Create<HttpContext, string>(httpContext => RateLimitPartition.GetFixedWindowLimiter(partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(), factory: partition => new FixedWindowRateLimiterOptions
    {
        AutoReplenishment = true,
        PermitLimit = 5,
        QueueLimit = 0,
        Window = TimeSpan.FromMinutes(1)
    }));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseRateLimiter();
app.MapControllers();
app.ConfigureCustomExceptionMiddleware();
app.Run();
