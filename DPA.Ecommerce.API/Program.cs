using DPA.Ecommerce.CORE.Core.Interfaces;
using DPA.Ecommerce.CORE.Core.Services;
using DPA.Ecommerce.CORE.Infrastructure.Data;
using DPA.Ecommerce.CORE.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _configuration = builder.Configuration;
var _connectionString = _configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<StoreDbueContext>(options =>
{
    options.UseSqlServer(_connectionString);
});

builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
