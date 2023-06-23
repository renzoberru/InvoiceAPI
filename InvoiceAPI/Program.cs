using System.Data;
using DataBase;
using InvoiceAPI.Repositories;
using InvoiceAPI.Services;
using InvoiceAPI.Configuration;
using Microsoft.Extensions.Configuration;
using DataBase.Settings;
using Microsoft.OpenApi.Models;
using System.Reflection;
using InvoiceAPI.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ApiKeyAuthorizationFilter));
});
builder.Services.Configure<JsonFileSettings>(builder.Configuration.GetSection("JsonFileSettings"));
builder.Services.Configure<SwaggerSettings>(builder.Configuration.GetSection("Swagger"));
builder.Services.AddSingleton<IJsonDbContext, JsonDbContext>();
builder.Services.AddSingleton<SwaggerConfiguration>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IBuyerService, BuyerService>();
builder.Services.AddScoped<IInvoicesByCommuneService, InvoicesByCommuneService>();

builder.Services.AddAutoMapper(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Configuración de Swagger
builder.Services.AddSwaggerGen();
var swaggerConfiguration = builder.Services.BuildServiceProvider().GetRequiredService<SwaggerConfiguration>();
swaggerConfiguration.Configure(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Invoice API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
