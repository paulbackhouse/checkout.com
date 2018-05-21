using Microsoft.AspNetCore.Builder;

namespace Checkout.Web.App.Extensions
{
    public static class MvcRoutesExtensions
    {
        public static IApplicationBuilder UseMvcRoutes(this IApplicationBuilder app)
        {
            return app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
