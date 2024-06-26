﻿using Microsoft.OpenApi.Models;

namespace Masterzdran.RestApi.Extensions.Models
{
    public sealed class SwaggerExtensionsOptions
    {
        public OpenApiInfo OpenApiInfo { get; set; }
        public OpenApiSecurityScheme OpenApiSecurityScheme { get; set; }
        public string SwaggerEndpoint { get; set; }
        public string ApiName { get; set; }
        public string Name { get; set; }
        public string OpenIdClientId { get; set; }
        public string XmlFile { get; set; }
        public string ApiKeyHeader { get; set; }
        public string ApiKeyHeaderToken { get; set; }

    }
}
