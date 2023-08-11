
using EfCore;
using EfCore.Data;
using EfCore.Services;
using EfCore.Services.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

//DB Context Adding
builder.Services.AddDbContext<ShopDbContext>();
builder.Services.AddMyServices();

//Product
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
/*var connection = builder.Configuration.GetConnectionString("ShopDb");
builder.Services.AddDbContext<ShopDbContext>(options =>
{
    options.UseNpgsql(connection);
});*/


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.Run();
