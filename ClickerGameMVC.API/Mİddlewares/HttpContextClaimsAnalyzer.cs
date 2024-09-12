using ClickerGameMVC.API.Mİddlewares;
using System.Security.Claims;

namespace ClickerGameMVC.API.Mİddlewares
{
    public class HttpContextClaimsAnalyzer
    {
        private readonly RequestDelegate _next;
        public HttpContextClaimsAnalyzer(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items["Roles"] = context.User.FindAll(ClaimTypes.Role).Select(role => role.Value).ToList();
            context.Items["Email"] = context.User.FindFirst(ClaimTypes.Email)?.Value;
            context.Items["Id"] = context.User.FindFirst("Id")?.Value;

            foreach (var item in context.Items)
            {
                Console.WriteLine($"{item} : {item.Value}");
            }

            await _next.Invoke(context);
        }
    }
}

public static class ClaimsAnalyzerExtension
{
    public static IApplicationBuilder UseClaimsAnalyer(this IApplicationBuilder app)
    {
        return app.UseMiddleware<HttpContextClaimsAnalyzer>();
    }
}
