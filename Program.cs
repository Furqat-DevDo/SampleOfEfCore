using EfCore;
using EfCore.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


var connectionString = builder.Configuration.GetConnectionString("ShopDb");

builder.Services.AddDbContext<ShopDbContext>(option =>
{
    option.UseNpgsql(connectionString);
});

builder.Services.AddDbContext<ShopDbContext>();
builder.Services.AddMyServices();

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
