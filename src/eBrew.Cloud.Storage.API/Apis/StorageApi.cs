using System.ComponentModel.DataAnnotations;
using eBrew.Cloud.Storage.API.DependencyInjection;
using eBrew.Cloud.Storage.API.Dto;
using eBrew.Cloud.Storage.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace eBrew.Cloud.Storage.API.Apis;

public static class StorageApi
{
    private const string Prefix = "/api/v1/storage";

    public static IEndpointRouteBuilder MapStorageApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/vaults/{name}/secrets", () => { });
        
        app.MapPost("/vaults", CreateVault);
        
        return app;
    }
    
    public static async Task<Results<Ok, ForbidHttpResult>> CreateVault(
        [AsParameters] StorageServices services,
        [FromHeader(Name = "x-apikey")] string accessKey,
        [FromBody] VaultDTO vaultDto)
    {
        var result = await services.KeyManager.AuthorizeKeyAsync(accessKey);
        
        if (!result.IsSuccess)
        {
            return TypedResults.Forbid();
        }
        
        await services.Repository.CreateVaultAsync(new Vault(result.Value, vaultDto.Name, vaultDto.Description));
        services.Logger.LogInformation($"Vault for user {result.Value} with name {vaultDto.Name} was created.");
        
        return TypedResults.Ok();
    }
}