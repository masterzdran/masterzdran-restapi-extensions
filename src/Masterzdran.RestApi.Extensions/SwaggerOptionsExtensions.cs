using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Masterzdran.RestApi.Extensions.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwaggerOptionsExtensions
    {


        public static IServiceCollection AddCustomSwaggerGenarator(this IServiceCollection services, SwaggerExtensionsOptions swaggerOptions)
        {
            services.AddSwaggerGen(c =>
            {
                // Add Swagger Documentation
                c.SwaggerInfoDocumentation(swaggerOptions);

                // Swagger Security Definition
                c.AddSwaggerSecurityDefinition(swaggerOptions);

                // Swagger Security Requirement
                c.AddSwaggerSecurityRequirement(swaggerOptions);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = swaggerOptions.XmlFile;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app, SwaggerExtensionsOptions swaggerOptions)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.CustomSwaggerUIOptions(swaggerOptions));
            return app;
        }


        public static void CustomSwaggerUIOptions(this SwaggerUIOptions options, SwaggerExtensionsOptions swaggerOptions)
        {
            options.SwaggerEndpoint(swaggerOptions.SwaggerEndpoint, $"{swaggerOptions.OpenApiInfo.Title} {swaggerOptions.OpenApiInfo.Version}");
            options.OAuthClientId(swaggerOptions.OpenIdClientId);
            options.OAuthUsePkce();
            options.OAuthScopeSeparator(" ");
        }


        public static void SwaggerInfoDocumentation(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            swaggerGenOptions.SwaggerDoc(swaggerOptions.Name, swaggerOptions.OpenApiInfo);
        }
        public static void AddImplicitFlow(this OpenApiOAuthFlows openApiOAuthFlows, SwaggerExtensionsOptions swaggerOptions)
        {
            if (swaggerOptions.OpenApiSecurityScheme == null
                || swaggerOptions.OpenApiSecurityScheme.Flows == null
                || swaggerOptions.OpenApiSecurityScheme.Flows.Implicit == null)
            {
                throw new ArgumentNullException("Invalid Implicit Flow Configuration.");
            }
            openApiOAuthFlows.Implicit = GetOpenAPIUpdatedFlow(swaggerOptions.OpenApiSecurityScheme.Flows.Implicit);

        }
        public static void AddPasswordFlow(this OpenApiOAuthFlows openApiOAuthFlows, SwaggerExtensionsOptions swaggerOptions)
        {
            if (swaggerOptions.OpenApiSecurityScheme == null
                || swaggerOptions.OpenApiSecurityScheme.Flows == null
                || swaggerOptions.OpenApiSecurityScheme.Flows.Password == null)
            {
                throw new ArgumentNullException("Invalid Password Flow Configuration.");
            }
            openApiOAuthFlows.Password = GetOpenAPIUpdatedFlow(swaggerOptions.OpenApiSecurityScheme.Flows.Password);
        }
        public static void AddClientCredentialsFlow(this OpenApiOAuthFlows openApiOAuthFlows, SwaggerExtensionsOptions swaggerOptions)
        {
            if (swaggerOptions.OpenApiSecurityScheme == null
                || swaggerOptions.OpenApiSecurityScheme.Flows == null
                || swaggerOptions.OpenApiSecurityScheme.Flows.ClientCredentials == null)
            {
                throw new ArgumentNullException("Invalid ClientCredentials Flow Configuration.");
            }
            openApiOAuthFlows.ClientCredentials = GetOpenAPIUpdatedFlow(swaggerOptions.OpenApiSecurityScheme.Flows.ClientCredentials);
        }
        public static void AddAuthorizationCodeFlow(this OpenApiOAuthFlows openApiOAuthFlows, SwaggerExtensionsOptions swaggerOptions)
        {
            if (swaggerOptions.OpenApiSecurityScheme == null
                || swaggerOptions.OpenApiSecurityScheme.Flows == null
                || swaggerOptions.OpenApiSecurityScheme.Flows.AuthorizationCode == null)
            {
                throw new ArgumentNullException("Invalid AuthorizationCode Flow Configuration.");
            }
            openApiOAuthFlows.AuthorizationCode = GetOpenAPIUpdatedFlow(swaggerOptions.OpenApiSecurityScheme.Flows.AuthorizationCode);
        }
        public static void AddSwaggerSecurityDefinition(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme();
            securityScheme.Description = swaggerOptions.OpenApiSecurityScheme.Description;
            securityScheme.Name = swaggerOptions.OpenApiSecurityScheme.Name;
            securityScheme.Type = swaggerOptions.OpenApiSecurityScheme.Type;
            securityScheme.Flows = new OpenApiOAuthFlows();

            AddIfExistOpenApiOAuthFlow(securityScheme.Flows, swaggerGenOptions, securityScheme, swaggerOptions);
        }
        public static void AddSwaggerSecurityRequirement(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            OpenApiSecurityRequirement openApiSecurityRequirement = new OpenApiSecurityRequirement();

            AddIfExistOpenApiSecurityRequirement(openApiSecurityRequirement, swaggerOptions);

            swaggerGenOptions.AddSecurityRequirement(openApiSecurityRequirement);
        }


        private static OpenApiOAuthFlow GetOpenAPIUpdatedFlow(OpenApiOAuthFlow openApiOAuthFlow)
        {

            Dictionary<string, string> scopes = new Dictionary<string, string>();

            foreach (var authorizationCodeScope in openApiOAuthFlow.Scopes)
            {
                var key = authorizationCodeScope.Key.Replace("__", ":");
                var value = authorizationCodeScope.Value;
                scopes.Add(key, value);
            }
            openApiOAuthFlow.Scopes = scopes;

            return openApiOAuthFlow;
        }

        private static void AddIfExistOpenApiSecurityRequirement(OpenApiSecurityRequirement openApiSecurityRequirement, SwaggerExtensionsOptions swaggerOptions)
        {
            string name = string.Empty;
            if (swaggerOptions.OpenApiSecurityScheme.Flows.Implicit != null)
            {
                var scopes = swaggerOptions.OpenApiSecurityScheme.Flows.Implicit.Scopes;
                name = $"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.Implicit)}";
                AddSecurityRequirementScopes(openApiSecurityRequirement, name, swaggerOptions, scopes);

            }
            if (swaggerOptions.OpenApiSecurityScheme.Flows.Password != null)
            {
                var scopes = swaggerOptions.OpenApiSecurityScheme.Flows.Password.Scopes;
                name = $"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.Password)}";
                AddSecurityRequirementScopes(openApiSecurityRequirement, name, swaggerOptions, scopes);
            }
            if (swaggerOptions.OpenApiSecurityScheme.Flows.AuthorizationCode != null)
            {
                var scopes = swaggerOptions.OpenApiSecurityScheme.Flows.AuthorizationCode.Scopes;
                name = $"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.AuthorizationCode)}";
                AddSecurityRequirementScopes(openApiSecurityRequirement, name, swaggerOptions, scopes);
            }
            if (swaggerOptions.OpenApiSecurityScheme.Flows.ClientCredentials != null)
            {
                var scopes = swaggerOptions.OpenApiSecurityScheme.Flows.ClientCredentials.Scopes;
                name = $"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.ClientCredentials)}";
                AddSecurityRequirementScopes(openApiSecurityRequirement, name, swaggerOptions, scopes);
            }
        }

        private static void AddSecurityRequirementScopes(OpenApiSecurityRequirement openApiSecurityRequirement, string name, SwaggerExtensionsOptions swaggerOptions, IDictionary<string, string> scopes)
        {
            OpenApiSecurityScheme openApiSecurityScheme = new OpenApiSecurityScheme();

            openApiSecurityScheme.Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = name
            };
            List<string> scopesList = scopes.Keys.ToList<string>();
            openApiSecurityRequirement.Add(openApiSecurityScheme, scopesList);
        }

        private static void AddIfExistOpenApiOAuthFlow(OpenApiOAuthFlows flows, SwaggerGenOptions swaggerGenOptions, OpenApiSecurityScheme securityScheme, SwaggerExtensionsOptions swaggerOptions)
        {
            if (swaggerOptions.OpenApiSecurityScheme.Flows.Implicit != null)
            {
                flows.AddImplicitFlow(swaggerOptions);
                swaggerGenOptions.AddSecurityDefinition($"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.Implicit)}", securityScheme);
            }
            if (swaggerOptions.OpenApiSecurityScheme.Flows.Password != null)
            {
                flows.AddPasswordFlow(swaggerOptions);
                swaggerGenOptions.AddSecurityDefinition($"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.Password)}", securityScheme);
            }
            if (swaggerOptions.OpenApiSecurityScheme.Flows.AuthorizationCode != null)
            {
                flows.AddAuthorizationCodeFlow(swaggerOptions);
                swaggerGenOptions.AddSecurityDefinition($"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.AuthorizationCode)}", securityScheme);
            }
            if (swaggerOptions.OpenApiSecurityScheme.Flows.ClientCredentials != null)
            {
                flows.AddClientCredentialsFlow(swaggerOptions);
                swaggerGenOptions.AddSecurityDefinition($"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.ClientCredentials)}", securityScheme);
            }
        }
    }
}
