using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi
{
    public class MyHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "X-CustomHeader",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            });
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "cookie",
                In = ParameterLocation.Cookie,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            });
        }

    }
}
