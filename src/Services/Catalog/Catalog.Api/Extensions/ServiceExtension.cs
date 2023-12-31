﻿using Catalog.Api.Repositories;

namespace Catalog.Api.Extensions;

public static class ServiceExtension
{
    public static void ServicesExtension(this IServiceCollection services)
    {
        services.AddScoped<ICatalogContext, CatalogContext>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
