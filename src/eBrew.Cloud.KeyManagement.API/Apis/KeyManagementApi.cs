using System.ComponentModel.DataAnnotations;
using eBrew.Cloud.KeyManagement.API.DependencyInjection;
using eBrew.Cloud.KeyManagement.Application.Commands.CreateKey;
using eBrew.Cloud.KeyManagement.Application.Dtos;
using eBrew.Cloud.KeyManagement.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace eBrew.Cloud.KeyManagement.API.Apis;

public static class KeyManagementApi
{
    private const string Prefix = "/api/v1/keymanagement";
    
    public static IEndpointRouteBuilder MapKeyManagementApi(this IEndpointRouteBuilder app)
    {
        app.MapPost("/keys", () => { });
        
        return app;
    }

    public static async Task<Results<Ok<ApiKeyOneTimeViewDTO>, UnauthorizedHttpResult>> CreateKey(
        [AsParameters] KeyManagementServices services,
        [FromBody] [MaxLength(300)] string? description)
    {
        var userId = services.IdentityService.GetUserIdentity();

        if (userId is null)
        {
            return TypedResults.Unauthorized();
        }

        return TypedResults.Ok(await services.Mediator.Send(new CreateKeyRequest(userId, description)));
    }
}