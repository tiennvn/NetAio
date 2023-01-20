using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Threading.Tasks;

namespace WebEmpty
{
    public class CheckAccessMiddleware
    {
        // Lưu middlewware tiếp theo trong Pipeline
        private readonly RequestDelegate _next;
        public CheckAccessMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path == "/xxx")
            {

                Log.Debug("Request");
                Log.Warning("Check Acess Middleware Result: Access not allowed");
                await Task.Run(
                  async () =>
                  {
                      string html = "<h1>Access not allowed</h1>";
                      httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                      httpContext.Response.Cookies.Append("AccessKey", "HaveNotKey");
                      await httpContext.Response.WriteAsync(html);
                  }
                );

            }
            else
            {
                var currentTime = DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss");
                // Thiết lập Header cho HttpResponse
                httpContext.Response.Headers.Add("throughCheckAcessMiddleware", new[] { currentTime });
                httpContext.Response.Cookies.Append("AccessKey", "KeyForAccess");
                httpContext.Response.Cookies.Append("AccessTime", currentTime);

                Log.Error("Check Acess Middleware Result: Access is valid");

                // Chuyển Middleware tiếp theo trong pipeline
                await _next(httpContext);

                Log.Debug("Response add process START");
                await httpContext.Response.WriteAsync(" - Middleware Response Add New message");
                Log.Debug("Response add process DONE");
            }
        }


    }
}
