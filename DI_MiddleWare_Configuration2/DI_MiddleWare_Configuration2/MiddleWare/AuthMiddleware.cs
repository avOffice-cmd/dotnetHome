using System.Text;

namespace DI_MiddleWare_Configuration2.MiddleWare
{
    public class AuthMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("No Authorization key in header");
                return;
            }

            var headers = context.Request.Headers["Authorization"].ToString();
            var creds = headers.Substring(6);
            var encodedString = Encoding.UTF8.GetString(Convert.FromBase64String(creds));

            // encode karne k baad jo string aayrgi hamare pas vo username and password
            // vo : seprated hogi that's why we are use spliting

            string[] credentialString = encodedString.Split(':'); // ye ek array hoga isliye hum isko string array define karte hai
            string userName = credentialString[0];
            string password = credentialString[1];
            if (userName != "nishant" && password != "nishant@123")
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Wrong credentials");
                return;
            }
            await next(context);
        }
    }
}
