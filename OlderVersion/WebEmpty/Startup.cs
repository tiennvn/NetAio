using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace WebEmpty
{
    public class Startup
    {
        // Đăng ký các dịch vụ sử dụng bởi ứng dụng, services là một DI container
        // Xem: https://xuanthulab.net/dependency-injection-di-trong-c-voi-servicecollection.html
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();       // Thêm dịch vụ dùng bộ nhớ lưu cache (session sử dụng dịch vụ này)
            services.AddSession();                      // Thêm  dịch vụ Session, dịch vụ này cunng cấp Middleware: 

            // Đăng kí middle ware vào DI container
            services.AddTransient<FrontMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Thêm StaticFileMiddleware - nếu Request là yêu cầu truy cập file tĩnh,
            // Nó trả ngay về Response nội dung file và là điểm cuối pipeline, nếu  khác nó gọi  Middleware phía sau trong Pipeline
            app.UseStaticFiles();

            // Thêm SessionMiddleware:  khôi phục, thiết lập - tạo ra session
            // gán context.Session, sau đó chuyển gọi ngay middleware
            // tiếp trong pipeline
            app.UseSession();

            // Thêm Custome Middleware Cách 1:
            app.UseMiddleware<FrontMiddleware>(); // Middleware này cần đăng kí vào DI container trước khi dùng
            app.UseMiddleware<CheckAccessMiddleware>();

            // Thêm Custome Middleware Cách 2:
            //app.UseFrontMiddleware();
            //app.UseCheckAccess();


            // Thêm EndpointRoutingMiddleware: ánh xạ Request gọi đến Endpoint (Middleware cuối)
            // phù hợp định nghĩa bởi EndpointMiddleware
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                // EndPoint(2) khi truy vấn đến /Testpost với phương thức post hoặc put
                endpoints.MapMethods("/testpost", new string[] { "get", "post", "put" }, async context =>
                {
                    await context.Response.WriteAsync("get/post/pust");
                });

                endpoints.Map("/any", async context =>
                {
                    await context.Response.WriteAsync("Any method");
                });

                //  EndPoint(2) -  Middleware khi truy cập /Home với phương thức GET - nó làm Middleware cuối Pipeline
                endpoints.MapGet("/home", async context =>
                {

                    Log.Debug("home: TESTTTTTTTTTTTTTTTTTTT");
                    int? count = context.Session.GetInt32("count");
                    count = (count != null) ? count + 1 : 1;
                    context.Session.SetInt32("count", count.Value);
                    await context.Response.WriteAsync($"Home page! {count}");

                });
            });

            // EndPoint(3)  app.Run tham số là hàm delegate tham số là HttpContex
            // - nó tạo điểm cuối của pipeline.
            app.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("Page not found");
            });
        }
    }
}
