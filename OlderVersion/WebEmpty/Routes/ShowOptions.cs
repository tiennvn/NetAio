using Microsoft.AspNetCore.Http;
using Serilog;
using System.Threading.Tasks;

namespace WebEmpty
{
    public class ShowOptions
    {
        public async Task ShowOption(HttpContext context, RequestDelegate next)
        {
            Log.Debug("ttt: " + context.Request.Path);

            var session = context.Session;
            Log.Debug("Session TYPE: {@session}", session.GetType());
            Log.Debug("Session: {@session}", session);

            await next(context);
        }
    }
}
