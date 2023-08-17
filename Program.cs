using EfCore;
using EfCore.Attributes;
using EfCore.Data;
using EfCore.Middlewares;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
   // // Filter Error Attribute ishlashi uchun kerak !!!!
   //options.Filters.Add<ErrorHandlingFilterAttribute>();
});

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

builder.Services.AddMyServices();

var app = builder.Build();

app.AddMySettings(app);
app.UseCategoryErrorHandlingMiddleware();

app.MapControllers();

app.Run();
