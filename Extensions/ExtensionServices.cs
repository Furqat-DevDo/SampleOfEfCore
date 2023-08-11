﻿using EfCore.Services;
using EfCore.Services.Interfaces;

namespace EfCore.Extensions;

public static class ExtensionServices
{
    public static IServiceCollection AddMyServices(this IServiceCollection services)
    {
        services.AddScoped<IShopService, ShopService>();
        services.AddScoped<IProductImageService, ProductImageService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IStorageService, StorageService>();
        services.AddScoped<ICompanyService, CompanyService>();
        return services;
    }
}
