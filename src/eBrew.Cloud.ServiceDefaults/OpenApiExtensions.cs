﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace eBrew.Cloud.ServiceDefaults;

public static class OpenApiExtensions
{
    public static IApplicationBuilder UseDefaultOpenApi(this WebApplication app)
    {
        var configuration = app.Configuration;
        var openApiSection = configuration.GetSection("OpenApi");

        if (!openApiSection.Exists())
        {
            return app;
        }

        app.UseSwagger();
        app.UseSwaggerUI(setup =>
        {
            // {
            //   "OpenApi": {
            //     "Endpoint: {
            //         "Name": 
            //     }
            //   }
            // }
            
            var pathBase = configuration["PATH_BASE"];
            var authSection = openApiSection.GetSection("Auth");
            var endpointSection = openApiSection.GetRequiredSection("Endpoint");

            var swaggerUrl = endpointSection["Url"] ?? $"{(!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty)}/swagger/v1/swagger.json";

            setup.SwaggerEndpoint(swaggerUrl, endpointSection.GetRequiredValue("Name"));
        });

        app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

        return app;
    }
    
    public static IHostApplicationBuilder AddDefaultOpenApi(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        var openApi = configuration.GetSection("OpenApi");

        if (!openApi.Exists())
        {
            return builder;
        }

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            // {
            //   "OpenApi": {
            //     "Document": {
            //         "Title": ..
            //         "Version": ..
            //         "Description": ..
            //     }
            //   }
            // }
            
            var document = openApi.GetRequiredSection("Document");

            var version = document.GetRequiredValue("Version") ?? "v1";

            options.SwaggerDoc(version, new OpenApiInfo
            {
                Title = document.GetRequiredValue("Title"),
                Version = version,
                Description = document.GetRequiredValue("Description")
            });
        });

        return builder;
    }
}