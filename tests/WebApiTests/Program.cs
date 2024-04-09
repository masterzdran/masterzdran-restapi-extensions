using Microsoft.OpenApi.Models;
using System.Reflection;
using Masterzdran.RestApi.Extensions.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.Text.Json.Serialization;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Configuration;
using Masterzdran.RestApi.Extensions.Middleware;
using Microsoft.Extensions.DependencyInjection;
using Masterzdran.RestApi.Extensions.Handler;

var builder = WebApplication.CreateBuilder(args);
SwaggerExtensionsOptions swaggerOptions = new SwaggerExtensionsOptions();
builder.Configuration.GetSection(SwaggerExtensionsConstants.SwaggerOptionsConfiguration).Bind(swaggerOptions);
var apiKey = swaggerOptions.ApiKeyHeaderToken;
var apikeyHeader = swaggerOptions.ApiKeyHeader;

// Add services to the container.

//Add Azure AD Authentication
//builder.Services
//.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//.AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddSingleton(new SimpleApiKeyAuthenticationSchemeOptions { ApiKey = apiKey });
builder.Services.AddAuthentication(apikeyHeader)
    .AddScheme<SimpleApiKeyAuthenticationSchemeOptions, SimpleApiKeyAuthenticationHandler>(
        apikeyHeader,
        opts => opts.ApiKey = apiKey
    );


builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Register the Swagger generator

builder.Services.AddCustomApiKeySwaggerGenerator(swaggerOptions);



builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger(swaggerOptions);
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
