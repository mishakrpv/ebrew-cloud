namespace eBrew.Cloud.Storage.API.Apis;

public static class StorageApi
{
    private const string Prefix = "/api/v1/storage";

    public static IEndpointRouteBuilder MapStorageApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/vaults/{name}/secrets", () => { });
        
        return app;
    }
}