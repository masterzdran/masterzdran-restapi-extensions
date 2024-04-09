using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Masterzdran.RestApi.Extensions.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwaggerOptionsExtensions
    {
        /// <summary>
        /// Add Custom OpenId Swagger Generator.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="swaggerOptions"></param>
        /// <returns></returns>
        private static IServiceCollection AddCustomOpenIdSwaggerGenerator(this IServiceCollection services, SwaggerExtensionsOptions swaggerOptions)
        {
            services.AddSwaggerGen(c =>
            {
                // Add Swagger Documentation
                c.SwaggerInfoDocumentation(swaggerOptions);

                // Swagger Security Definition
                c.AddSwaggerOpenIdSecurityDefinition(swaggerOptions);

                // Swagger Security Requirement
                c.AddSwaggerOpenIdSecurityRequirement(swaggerOptions);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = swaggerOptions.XmlFile;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            return services;
        }
        /// <summary>
        /// Add Custom ApiKey Swagger Generator.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="swaggerOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomApiKeySwaggerGenerator(this IServiceCollection services, SwaggerExtensionsOptions swaggerOptions)
        {
            services.AddSwaggerGen(c =>
            {
                // Add Swagger Documentation
                c.SwaggerInfoDocumentation(swaggerOptions);

                // Swagger Security Definition
                c.AddSwaggerApiKeySecurityDefinition(swaggerOptions);

                // Swagger Security Requirement
                c.AddSwaggerApiKeySecurityRequirement(swaggerOptions);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = swaggerOptions.XmlFile;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            return services;
        }
        /// <summary>
        /// Add Custom OAuth2 Password Flow to Swagger Generator.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="swaggerOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomOAuth2WithPasswordFlowSwaggerGenerator(this IServiceCollection services, SwaggerExtensionsOptions swaggerOptions)
        {
            services.AddSwaggerGen(c =>
            {
                // Add Swagger Documentation
                c.SwaggerInfoDocumentation(swaggerOptions);

                // Swagger Security Definition
                c.AddSwaggerOAuth2WithPasswordFlowSecurityDefinition(swaggerOptions);

                // Swagger Security Requirement
                c.AddSwaggerOAuth2WithPasswordFlowSecurityRequirement(swaggerOptions);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = swaggerOptions.XmlFile;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            return services;
        }
        /// <summary>
        /// Add Custom OAuth2 Implicit Flow to Swagger Generator.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="swaggerOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomOAuth2WithImplicitFlowSwaggerGenerator(this IServiceCollection services, SwaggerExtensionsOptions swaggerOptions)
        {
            services.AddSwaggerGen(c =>
            {
                // Add Swagger Documentation
                c.SwaggerInfoDocumentation(swaggerOptions);

                // Swagger Security Definition
                c.AddSwaggerOAuth2WithImplicitFlowSecurityDefinition(swaggerOptions);

                // Swagger Security Requirement
                c.AddSwaggerOAuth2WithImplicitFlowSecurityRequirement(swaggerOptions);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = swaggerOptions.XmlFile;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            return services;
        }
        /// <summary>
        /// Add Custom OAuth2 Client Credentials Flow to Swagger Generator.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="swaggerOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomOAuth2WithClientCredentialsFlowSwaggerGenerator(this IServiceCollection services, SwaggerExtensionsOptions swaggerOptions)
        {
            services.AddSwaggerGen(c =>
            {
                // Add Swagger Documentation
                c.SwaggerInfoDocumentation(swaggerOptions);

                // Swagger Security Definition
                c.AddSwaggerOAuth2WithClientCredentialsFlowSecurityDefinition(swaggerOptions);

                // Swagger Security Requirement
                c.AddSwaggerOAuth2WithClientCredentialsFlowSecurityRequirement(swaggerOptions);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = swaggerOptions.XmlFile;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            return services;
        }
        /// <summary>
        /// Add Custom OAuth2 Authorization Code Flow to Swagger Generator.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="swaggerOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomOAuth2WithAuthorizationCodeFlowSwaggerGenerator(this IServiceCollection services, SwaggerExtensionsOptions swaggerOptions)
        {
            services.AddSwaggerGen(c =>
            {
                // Add Swagger Documentation
                c.SwaggerInfoDocumentation(swaggerOptions);

                // Swagger Security Definition
                c.AddSwaggerOAuth2WithAuthorizationCodeFlowSecurityDefinition(swaggerOptions);

                // Swagger Security Requirement
                c.AddSwaggerOAuth2WithAuthorizationCodeFlowSecurityRequirement(swaggerOptions);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = swaggerOptions.XmlFile;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            return services;
        }
        /// <summary>
        /// Ad Custom Swagger Generator
        /// </summary>
        /// <param name="services"></param>
        /// <param name="swaggerOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomSwaggerGenerator(this IServiceCollection services, SwaggerExtensionsOptions swaggerOptions)
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
        /// <summary>
        /// Use Custom Swagger with PKCE.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="swaggerOptions"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app, SwaggerExtensionsOptions swaggerOptions)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.CustomSwaggerUIOptions(swaggerOptions));
            return app;
        }
        /// <summary>
        /// Custom Swagger UI Options with PKCE.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="swaggerOptions"></param>
        public static void CustomSwaggerUIOptions(this SwaggerUIOptions options, SwaggerExtensionsOptions swaggerOptions)
        {
            options.SwaggerEndpoint(swaggerOptions.SwaggerEndpoint, $"{swaggerOptions.OpenApiInfo.Title} {swaggerOptions.OpenApiInfo.Version}");
            options.OAuthClientId(swaggerOptions.OpenIdClientId);
            options.OAuthUsePkce();
            options.OAuthScopeSeparator(" ");
        }
        /// <summary>
        /// Swagger Info Documentation.
        /// </summary>
        /// <param name="swaggerGenOptions"></param>
        /// <param name="swaggerOptions"></param>
        public static void SwaggerInfoDocumentation(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            swaggerGenOptions.SwaggerDoc(swaggerOptions.Name, swaggerOptions.OpenApiInfo);
        }
        /// <summary>
        /// Add OAuth2 Implicit Flow.
        /// </summary>
        /// <param name="openApiOAuthFlows"></param>
        /// <param name="swaggerOptions"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddOAuth2ImplicitFlow(this OpenApiOAuthFlows openApiOAuthFlows, SwaggerExtensionsOptions swaggerOptions)
        {
            if (swaggerOptions.OpenApiSecurityScheme == null
                || swaggerOptions.OpenApiSecurityScheme.Flows == null
                || swaggerOptions.OpenApiSecurityScheme.Flows.Implicit == null)
            {
                throw new ArgumentNullException("Invalid Implicit Flow Configuration.");
            }
            openApiOAuthFlows.Implicit = GetOpenAPIUpdatedFlow(swaggerOptions.OpenApiSecurityScheme.Flows.Implicit);

        }
        /// <summary>
        /// Add OAuth2 Password Flow.
        /// </summary>
        /// <param name="openApiOAuthFlows"></param>
        /// <param name="swaggerOptions"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddOAuth2PasswordFlow(this OpenApiOAuthFlows openApiOAuthFlows, SwaggerExtensionsOptions swaggerOptions)
        {
            if (swaggerOptions.OpenApiSecurityScheme == null
                || swaggerOptions.OpenApiSecurityScheme.Flows == null
                || swaggerOptions.OpenApiSecurityScheme.Flows.Password == null)
            {
                throw new ArgumentNullException("Invalid Password Flow Configuration.");
            }
            openApiOAuthFlows.Password = GetOpenAPIUpdatedFlow(swaggerOptions.OpenApiSecurityScheme.Flows.Password);
        }
        /// <summary>
        /// Add OAuth2 Client Credentials Flow.
        /// </summary>
        /// <param name="openApiOAuthFlows"></param>
        /// <param name="swaggerOptions"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddOAuth2ClientCredentialsFlow(this OpenApiOAuthFlows openApiOAuthFlows, SwaggerExtensionsOptions swaggerOptions)
        {
            if (swaggerOptions.OpenApiSecurityScheme == null
                || swaggerOptions.OpenApiSecurityScheme.Flows == null
                || swaggerOptions.OpenApiSecurityScheme.Flows.ClientCredentials == null)
            {
                throw new ArgumentNullException("Invalid ClientCredentials Flow Configuration.");
            }
            openApiOAuthFlows.ClientCredentials = GetOpenAPIUpdatedFlow(swaggerOptions.OpenApiSecurityScheme.Flows.ClientCredentials);
        }
        /// <summary>
        /// Add OAuth2 Authorization Code Flow.
        /// </summary>
        /// <param name="openApiOAuthFlows"></param>
        /// <param name="swaggerOptions"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddOAuth2AuthorizationCodeFlow(this OpenApiOAuthFlows openApiOAuthFlows, SwaggerExtensionsOptions swaggerOptions)
        {
            if (swaggerOptions.OpenApiSecurityScheme == null
                || swaggerOptions.OpenApiSecurityScheme.Flows == null
                || swaggerOptions.OpenApiSecurityScheme.Flows.AuthorizationCode == null)
            {
                throw new ArgumentNullException("Invalid AuthorizationCode Flow Configuration.");
            }
            openApiOAuthFlows.AuthorizationCode = GetOpenAPIUpdatedFlow(swaggerOptions.OpenApiSecurityScheme.Flows.AuthorizationCode);
        }
        /// <summary>
        /// AddSwagger OAuth2 With Implicit Flow Security Definition.
        /// </summary>
        /// <param name="swaggerGenOptions"></param>
        /// <param name="swaggerOptions"></param>
        public static void AddSwaggerOAuth2WithImplicitFlowSecurityDefinition(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
            {
                Description = swaggerOptions.OpenApiSecurityScheme.Description,
                Name = swaggerOptions.OpenApiSecurityScheme.Name,
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows()
            };
            securityScheme.Flows.AddOAuth2ImplicitFlow(swaggerOptions);
            var name = $"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.Implicit)}";
            swaggerGenOptions.AddSecurityDefinition(name, securityScheme);
        }
        /// <summary>
        /// Add Swagger OAuth2 With Client Credentials Flow Security Definition.
        /// </summary>
        /// <param name="swaggerGenOptions"></param>
        /// <param name="swaggerOptions"></param>
        public static void AddSwaggerOAuth2WithClientCredentialsFlowSecurityDefinition(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
            {
                Description = swaggerOptions.OpenApiSecurityScheme.Description,
                Name = swaggerOptions.OpenApiSecurityScheme.Name,
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows()
            };
            securityScheme.Flows.AddOAuth2ClientCredentialsFlow(swaggerOptions);
            var name = $"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.ClientCredentials)}";
            swaggerGenOptions.AddSecurityDefinition(name, securityScheme);
        }
        /// <summary>
        /// Add Swagger OAuth2 With Authorization Code Flow Security Definition.
        /// </summary>
        /// <param name="swaggerGenOptions"></param>
        /// <param name="swaggerOptions"></param>
        public static void AddSwaggerOAuth2WithAuthorizationCodeFlowSecurityDefinition(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
            {
                Description = swaggerOptions.OpenApiSecurityScheme.Description,
                Name = swaggerOptions.OpenApiSecurityScheme.Name,
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows()
            };
            securityScheme.Flows.AddOAuth2AuthorizationCodeFlow(swaggerOptions);
            var name = $"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.AuthorizationCode)}";
            swaggerGenOptions.AddSecurityDefinition(name, securityScheme);
        }
        /// <summary>
        /// Add Swagger OAuth2 With Password Flow Security Definition.
        /// </summary>
        /// <param name="swaggerGenOptions"></param>
        /// <param name="swaggerOptions"></param>
        public static void AddSwaggerOAuth2WithPasswordFlowSecurityDefinition(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
            {
                Description = swaggerOptions.OpenApiSecurityScheme.Description,
                Name = swaggerOptions.OpenApiSecurityScheme.Name,
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows()
            };
            securityScheme.Flows.AddOAuth2PasswordFlow(swaggerOptions);
            var name = $"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.Password)}";
            swaggerGenOptions.AddSecurityDefinition(name, securityScheme);
        }

        /// <summary>
        /// Add Swagger OpenId Security Definition.
        /// </summary>
        /// <param name="swaggerGenOptions"></param>
        /// <param name="swaggerOptions"></param>
        private static void AddSwaggerOpenIdSecurityDefinition(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
            {
                Description = swaggerOptions.OpenApiSecurityScheme.Description,
                Name = swaggerOptions.OpenApiSecurityScheme.Name,
                Type = SecuritySchemeType.Http,
                In = ParameterLocation.Header,
                Scheme = "bearer",
                BearerFormat = "JWT"
            };
            var name = $"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Name)}";
            swaggerGenOptions.AddSecurityDefinition(name, securityScheme);
        }
        /// <summary>
        /// Add Swagger ApiKey Security Definition.
        /// </summary>
        /// <param name="swaggerGenOptions"></param>
        /// <param name="swaggerOptions"></param>
        public static void AddSwaggerApiKeySecurityDefinition(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
            {
                Description = swaggerOptions.OpenApiSecurityScheme.Description,
                Name = swaggerOptions.ApiKeyHeader,
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header
            };
            var name = $"{swaggerOptions.ApiKeyHeader}_{nameof(swaggerOptions.ApiKeyHeader)}";
            swaggerGenOptions.AddSecurityDefinition(name, securityScheme);
        }
        /// <summary>
        /// Add Swagger Security Definition.
        /// </summary>
        /// <param name="swaggerGenOptions"></param>
        /// <param name="swaggerOptions"></param>
        public static void AddSwaggerSecurityDefinition(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
            {
                Description = swaggerOptions.OpenApiSecurityScheme.Description,
                Name = swaggerOptions.OpenApiSecurityScheme.Name,
                Type = swaggerOptions.OpenApiSecurityScheme.Type,
                Flows = new OpenApiOAuthFlows()
            };

            AddIfExistOpenApiOAuthFlow(securityScheme.Flows, swaggerGenOptions, securityScheme, swaggerOptions);
        }
        /// <summary>
        /// Add Swagger OAuth2 With Implicit Flow Security Requirement.
        /// </summary>
        /// <param name="swaggerGenOptions"></param>
        /// <param name="swaggerOptions"></param>
        public static void AddSwaggerOAuth2WithImplicitFlowSecurityRequirement(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            var name = $"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.Implicit)}";
            var scopes = swaggerOptions.OpenApiSecurityScheme.Flows.Implicit.Scopes;
            var openApiSecurityRequirement = AddSwaggerOAuth2SecurityRequirement(swaggerOptions, scopes, name);
            swaggerGenOptions.AddSecurityRequirement(openApiSecurityRequirement);
        }
        /// <summary>
        /// Add Swagger OAuth2 With Client Credentials Flow Security Requirement.
        /// </summary>
        /// <param name="swaggerGenOptions"></param>
        /// <param name="swaggerOptions"></param>
        public static void AddSwaggerOAuth2WithClientCredentialsFlowSecurityRequirement(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            var scopes = swaggerOptions.OpenApiSecurityScheme.Flows.ClientCredentials.Scopes;
            string name = $"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.ClientCredentials)}";
            var openApiSecurityRequirement = AddSwaggerOAuth2SecurityRequirement(swaggerOptions, scopes, name);
            swaggerGenOptions.AddSecurityRequirement(openApiSecurityRequirement);
        }
        /// <summary>
        /// Add Swagger OAuth2 With Authorization Code Flow Security Requirement.
        /// </summary>
        /// <param name="swaggerGenOptions"></param>
        /// <param name="swaggerOptions"></param>
        public static void AddSwaggerOAuth2WithAuthorizationCodeFlowSecurityRequirement(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            var scopes = swaggerOptions.OpenApiSecurityScheme.Flows.AuthorizationCode.Scopes;
            string name = $"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.AuthorizationCode)}";
            var openApiSecurityRequirement = AddSwaggerOAuth2SecurityRequirement(swaggerOptions, scopes, name);
            swaggerGenOptions.AddSecurityRequirement(openApiSecurityRequirement);
        }
        /// <summary>
        /// Add Swagger OAuth2 With Password Flow Security Requirement.
        /// </summary>
        /// <param name="swaggerGenOptions"></param>
        /// <param name="swaggerOptions"></param>
        public static void AddSwaggerOAuth2WithPasswordFlowSecurityRequirement(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            var scopes = swaggerOptions.OpenApiSecurityScheme.Flows.Password.Scopes;
            string name = $"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.Password)}";
            var openApiSecurityRequirement = AddSwaggerOAuth2SecurityRequirement(swaggerOptions, scopes, name);
            swaggerGenOptions.AddSecurityRequirement(openApiSecurityRequirement);
        }
        /// <summary>
        /// Add Swagger Api Key Security Requirement.
        /// </summary>
        /// <param name="swaggerGenOptions"></param>
        /// <param name="swaggerOptions"></param>
        public static void AddSwaggerApiKeySecurityRequirement(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            var name = $"{swaggerOptions.ApiKeyHeader}_{nameof(swaggerOptions.ApiKeyHeader)}";
            var scopes = new Dictionary<string, string>();
            var openApiSecurityRequirement = AddSwaggerApiKeySecurityRequirement(swaggerOptions, scopes, name);
            swaggerGenOptions.AddSecurityRequirement(openApiSecurityRequirement);
        }
        /// <summary>
        /// Add Swagger OpenId Security Requirement.
        /// </summary>
        /// <param name="swaggerGenOptions"></param>
        /// <param name="swaggerOptions"></param>
        private static void AddSwaggerOpenIdSecurityRequirement(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            var name = $"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Name)}";
            var scopes = new Dictionary<string, string>();
            var openApiSecurityRequirement = AddSwaggerApiKeySecurityRequirement(swaggerOptions, scopes, name);
            swaggerGenOptions.AddSecurityRequirement(openApiSecurityRequirement);
        }
        /// <summary>
        /// Add Swagger Security Requirement.
        /// </summary>
        /// <param name="swaggerGenOptions"></param>
        /// <param name="swaggerOptions"></param>
        public static void AddSwaggerSecurityRequirement(this SwaggerGenOptions swaggerGenOptions, SwaggerExtensionsOptions swaggerOptions)
        {
            OpenApiSecurityRequirement openApiSecurityRequirement = new OpenApiSecurityRequirement();

            AddIfExistOpenApiSecurityRequirement(openApiSecurityRequirement, swaggerOptions);

            swaggerGenOptions.AddSecurityRequirement(openApiSecurityRequirement);
        }
        private static OpenApiSecurityRequirement AddSwaggerApiKeySecurityRequirement(SwaggerExtensionsOptions swaggerOptions, IDictionary<string, string> scopes, string name)
        {
            OpenApiSecurityRequirement openApiSecurityRequirement = new OpenApiSecurityRequirement();
            AddSecurityRequirementScopes(openApiSecurityRequirement, name, swaggerOptions, scopes);
            return openApiSecurityRequirement;
        }
        private static OpenApiSecurityRequirement AddSwaggerOAuth2SecurityRequirement(SwaggerExtensionsOptions swaggerOptions, IDictionary<string, string> scopes, string name)
        {
            OpenApiSecurityRequirement openApiSecurityRequirement = new OpenApiSecurityRequirement();
            AddSecurityRequirementScopes(openApiSecurityRequirement, name, swaggerOptions, scopes);
            return openApiSecurityRequirement;
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
                flows.AddOAuth2ImplicitFlow(swaggerOptions);
                swaggerGenOptions.AddSecurityDefinition($"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.Implicit)}", securityScheme);
            }
            if (swaggerOptions.OpenApiSecurityScheme.Flows.Password != null)
            {
                flows.AddOAuth2PasswordFlow(swaggerOptions);
                swaggerGenOptions.AddSecurityDefinition($"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.Password)}", securityScheme);
            }
            if (swaggerOptions.OpenApiSecurityScheme.Flows.AuthorizationCode != null)
            {
                flows.AddOAuth2AuthorizationCodeFlow(swaggerOptions);
                swaggerGenOptions.AddSecurityDefinition($"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.AuthorizationCode)}", securityScheme);
            }
            if (swaggerOptions.OpenApiSecurityScheme.Flows.ClientCredentials != null)
            {
                flows.AddOAuth2ClientCredentialsFlow(swaggerOptions);
                swaggerGenOptions.AddSecurityDefinition($"{swaggerOptions.OpenApiSecurityScheme.Name}_{nameof(swaggerOptions.OpenApiSecurityScheme.Flows.ClientCredentials)}", securityScheme);
            }
        }
    }
}
