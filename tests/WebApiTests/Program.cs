using Microsoft.OpenApi.Models;
using System.Reflection;
using Masterzdran.RestApi.Extensions.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.Text.Json.Serialization;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));


builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Register the Swagger generator, defining 1 or more Swagger documents
SwaggerExtensionsOptions swaggerOptions = new SwaggerExtensionsOptions();
builder.Configuration.GetSection(SwaggerExtensionsConstants.SwaggerOptionsConfiguration).Bind(swaggerOptions);
builder.Services.AddCustomSwaggerGenarator(swaggerOptions);



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
