using Microsoft.AspNetCore.Builder;

namespace WebEmpty
{
    public static class CustomExtensions
    {
        // Mở rộng cho IApplicationBuilder phương thức UseCheckAccess
        public static IApplicationBuilder UseCheckAccess(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckAccessMiddleware>();
        }

        public static IApplicationBuilder UseFrontMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FrontMiddleware>();
        }
    }
}
