using Microsoft.OpenApi.Models;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(config =>
            {
                var apiSecurity = new OpenApiSecurityRequirement{
                          {
                             new OpenApiSecurityScheme{
                                 Reference = new OpenApiReference{
                                 Id = "Bearer", //The name of the previously defined security scheme.
                                 Type = ReferenceType.SecurityScheme
                            }
                          },new List<string>()  }};
                config.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                config.AddSecurityRequirement(apiSecurity);

                config.OperationFilter<MyHeaderFilter>();

                config.SwaggerDoc("v1", new OpenApiInfo { Title = "Web API", Version = "V1" });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseSwaggerUI(config =>
                {
                    config.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
                    config.UseRequestInterceptor("(req) => { req.headers['x-my-custom-header'] = 'MyCustomValue'; return req; }");
                    config.UseResponseInterceptor("(res) => { console.log('Custom interceptor intercepted response from:', res.url); return res; }");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}