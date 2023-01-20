using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Text;

namespace WebEmpty
{
    public class Startup
    {
        IServiceCollection _services;
        // Đăng ký các dịch vụ sử dụng bởi ứng dụng, services là một DI container
        // Xem: https://xuanthulab.net/dependency-injection-di-trong-c-voi-servicecollection.html
        public void ConfigureServices(IServiceCollection services)
        {
            _services = services;

            // Thêm dịch vụ dùng bộ nhớ lưu cache (session sử dụng dịch vụ này)
            // Đăng ký dịch vụ lưu cache trong bộ nhớ(Session sẽ sử dụng nó)
            services.AddDistributedMemoryCache();

            // Thêm  dịch vụ Session, dịch vụ này cunng cấp Middleware
            // Đăng ký dịch vụ Session
            // Đặt tên Session - tên này sử dụng ở Browser (Cookie)
            // Thời gian tồn tại của Session
            services.AddSession(cfg =>
            {
                cfg.Cookie.Name = "xuanthulab";
                cfg.IdleTimeout = new TimeSpan(0, 60, 0);
            });

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

            app.Map("/ShowOptions", appOptions =>
            {
                appOptions.Run(async (context) =>
                {

                    StringBuilder stb = new StringBuilder();
                    IConfiguration configuration = appOptions.ApplicationServices.GetService<IConfiguration>();

                    var testoptions = configuration.GetSection("TestOptions");  // Đọc một Section trả về IConfigurationSection
                    var opt_key1 = testoptions["opt_key1"];                  // Đọc giá trị trong Section
                    var k1 = testoptions.GetSection("opt_key2")["k1"]; // Đọc giá trị trong Section con
                    var k2 = configuration["TestOptions:opt_key2:k2"]; // Đọc giá trị trong Section

                    stb.Append($"   TestOptions.opt_key1:  {opt_key1}\n");
                    stb.Append($"TestOptions.opt_key2.k1:  {k1}\n");
                    stb.Append($"TestOptions.opt_key2.k2:  {k2}\n");

                    await context.Response.WriteAsync(stb.ToString());


                });
            });

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

                endpoints.Map("/RequestInfo", async context =>
                {
                    // xây dựng chức năng /RequestInfo ở đây
                    await context.Response.WriteAsync("/RequestInfo");
                });

                endpoints.MapGet("/Encoding", async context =>
                {
                    // xây dựng chức năng Encoding  ở đây
                    await context.Response.WriteAsync("/Encoding");
                });

                endpoints.MapGet("/Cookies/{*action}", async context =>
                {
                    // xây dựng chức năng Cookies ở đây
                    await context.Response.WriteAsync("/Cookies");
                });

            });

            // Điểm rẽ nhánh pipeline khi URL là /Json
            app.Map("/Json", app =>
            {
                app.Run(async context =>
                {
                    // code ở đây
                    await context.Response.WriteAsync("/Json");
                });
            });

            // Điểm rẽ nhánh pipeline khi URL là /Form
            app.Map("/Form", app =>
            {
                app.Run(async context =>
                {
                    // code ở đây
                    await context.Response.WriteAsync("/Form");
                });
            });

            app.Map("/allservice", app01 =>
            {
                app01.Run(async (context) =>
                {

                    var result = "<body>";

                    foreach (var service in _services)
                    {
                        string src = service.ServiceType.Name.ToString() + "-----" +
                        service.Lifetime.ToString() + "-----" +
                        service.ServiceType.FullName + "</br>";

                        result += src;

                    }

                    result += "</body>";
                    await context.Response.WriteAsync(result);
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
