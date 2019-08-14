using SOS.API.Filters;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace SOS.API.SwaggerExt
{
    public class RestaurantHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();

            var authorizeAttributes = apiDescription
                .ActionDescriptor.GetCustomAttributes<QRCodeAttribute>();

            if (!authorizeAttributes.Any())
                return;

            bool required = authorizeAttributes.First().GetRequired();

            operation.parameters.Add(new Parameter
            {
                name = "QRCodeRestaurantId",
                @in = "header",
                description = "Restaurant Id From QRCode",
                required = required,
                type = "integer",
                @default = 1
            });

            operation.parameters.Add(new Parameter
            {
                name = "QRCodeTableId",
                @in = "header",
                description = "Table Id From QRCode",
                required = required,
                type = "integer",
                @default = 1
            });

        }
    }
}