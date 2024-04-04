using Microsoft.OpenApi.Models;
using System.Reflection;

using Masterzdran.RestApi.Extensions.Models;
using Swashbuckle.AspNetCore.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Register the Swagger generator, defining 1 or more Swagger documents
SwaggerExtensionsOptions swaggerOptions = new SwaggerExtensionsOptions();
builder.Configuration.GetSection(SwaggerExtensionsConstants.SwaggerOptionsConfiguration).Bind(swaggerOptions);

builder.Services.AddCustomSwaggerGenarator(swaggerOptions);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger(swaggerOptions);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
