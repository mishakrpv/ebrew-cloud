using Ardalis.Result;

namespace eBrew.Cloud.Storage.API.Infrastructure.ServiceInterfaces;

public interface IKeyManagementService
{
    Task<Result<string>> AuthorizeKeyAsync(string key);
}