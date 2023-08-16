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
        services.AddScoped<IStaffService, StaffService>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
