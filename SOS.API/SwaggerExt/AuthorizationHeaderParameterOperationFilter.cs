using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace SOS.API.SwaggerExt
{
    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();

            var authorizeAttributes = apiDescription
                .ActionDescriptor.GetCustomAttributes<AuthorizeAttribute>();
            
            if (!authorizeAttributes.Any())
                return;

            operation.parameters.Add(new Parameter
            {
                name = "Content",
                @in = "header",
                description = "content application/json",
                required = true,
                type = "string",
                @default = "application/json"
            });

            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in = "header",
                description = "access token",
                required = true,
                type = "string"
            });
        }
    }
}