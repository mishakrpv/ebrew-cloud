﻿using eBrew.Cloud.ServiceDefaults;
using eBrew.Cloud.Storage.API.Infrastructure.ServiceInterfaces;
using eBrew.Cloud.Storage.API.Infrastructure.Services;
using eBrew.Cloud.Storage.DataAccess.Impl;
using eBrew.Cloud.Storage.DataAccess.Impl.Repositories;
using eBrew.Cloud.Storage.DataAccess.Interfaces.Repositories;

namespace eBrew.Cloud.Storage.API.Extensions;

public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.AddDefaultAuthentication();
        
        builder.AddNpgsqlDbContext<StorageContext>("storagedb");

        builder.Services.AddSingleton<IKeyManagementService, GrpcKeyManagementService>();

        builder.Services.AddScoped<IVaultRepository, EFVaultRepository>();
    }
}