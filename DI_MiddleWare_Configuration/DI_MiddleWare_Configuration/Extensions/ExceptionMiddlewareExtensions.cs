using DI_MiddleWare_Configuration.CustomMiddlewares;

namespace DI_MiddleWare_Configuration.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
