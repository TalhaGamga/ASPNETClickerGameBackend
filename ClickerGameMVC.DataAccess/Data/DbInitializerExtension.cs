using ClickerGameMVC.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ClickerGameMVC.DataAccess.Data
{
    public static class DbInitializerExtension
    {
        public static IApplicationBuilder UseSeedDb(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));
            using var scope = app.ApplicationServices.CreateScope();

            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();

            DBSeeder.Seed(context);

            return app;
        }
    }
}
