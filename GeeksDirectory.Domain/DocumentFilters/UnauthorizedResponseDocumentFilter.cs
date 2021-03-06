﻿using GeeksDirectory.Domain.Responses;
using GeeksDirectory.Domain.SchemaFilters;

using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeeksDirectory.Domain.DocumentFilters
{
    public class UnauthorizedResponseDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Components.Schemas.Add(
                key: nameof(UnauthorizedErrorResponse),
                value: new OpenApiSchema()
                {
                    Example = SchemaFiltersMock.GetErrorResponse("Unauthorized")
                });
        }
    }
}
