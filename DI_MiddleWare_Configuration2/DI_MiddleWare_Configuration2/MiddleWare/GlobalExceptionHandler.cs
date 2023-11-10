namespace DI_MiddleWare_Configuration2.MiddleWare
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            try
            {
                _next(context);
            }
            catch (Exception ex)
            {
               
            }
        }


    }
}
