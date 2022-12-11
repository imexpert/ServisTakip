﻿using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.Core.ApiDoc
{
    /// <summary>
    /// Plugin made to send Enum values and names correctly in APIs.
    /// </summary>
    internal class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                var enumValues = schema.Enum.ToArray();
                var i = 0;
                schema.Enum.Clear();
                foreach (var n in Enum.GetNames(context.Type).ToList())
                {
                    schema.Enum.Add(new OpenApiString(n));
                    schema.Title = ((OpenApiPrimitive<int>)enumValues[i]).Value.ToString();
                    i++;
                }
            }
        }
    }
}
