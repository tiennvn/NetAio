using Microsoft.AspNetCore.Http;
using Serilog;
using System.Threading.Tasks;

namespace WebEmpty
{
    /// <summary>
    /// Tạo middleware bằng cách triển khai interface
    /// </summary>
    public class FrontMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Log.Debug("FrontMiddleware: " + context.Request.Path);

            var session = context.Session;
            Log.Debug("Session TYPE: {@session}", session.GetType());
            Log.Debug("Session: {@session}", session);

            await next(context);
        }
    }
}
