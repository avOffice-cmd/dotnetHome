namespace DI_MiddleWare_Configuration2
{
    public class CustomMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Welcome to the tech yatra- custom middleware component is working");
        }
    }
}
