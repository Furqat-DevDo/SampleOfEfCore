using EfCore.Middlewares;
using EfCore.Services;
using EfCore.Services.Interfaces;

namespace EfCore;

public static class ExtensionServices
{
    public static IServiceCollection AddMyServices (this IServiceCollection services)
    {
        services.AddScoped<IShopService,ShopService>();
        services.AddScoped<IProductImageService,ProductImageService>();
        services.AddScoped<ICategoryImageService,CategoryImageService>();
        services.AddScoped<ICategoryService,CategoryService>();
        services.AddScoped<IStuffService, StuffService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IStorageService, StorageService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICompanyService, CompanyService>();
        
        services.AddTransient<GlobalExceptionHandlingMiddleWare> ();
        return services;
    }

    public static IApplicationBuilder AddMySettings(this IApplicationBuilder app,
        WebApplication web)
    {
        // Errors Controller ishlashi uchun kerak!!!!
        //app.UseExceptionHandler("/error");

        // MiddleWare bilan Handle qilish uchun ishlating !!!
        app.UseMiddleware<GlobalExceptionHandlingMiddleWare>();
        if (web.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }

        return app;
    }
}
