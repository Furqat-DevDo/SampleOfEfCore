using EfCore;
using EfCore.Data;
using EfCore.Services;
using EfCore.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//DB Context Adding
builder.Services.AddDbContext<ShopDbContext>();



builder.Services.AddDbContext<ShopDbContext>();
builder.Services.AddMyServices();

//Product
builder.Services.AddScoped<IProductService,ProductService>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.Run();
