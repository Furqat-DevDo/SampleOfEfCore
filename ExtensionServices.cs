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

        return services;
    }
}
