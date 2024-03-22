using Ardalis.Result;
using eBrew.Cloud.KeyManagement.Application.Dtos;
using MediatR;

namespace eBrew.Cloud.KeyManagement.Application.Commands.CreateKey;

public sealed record CreateKeyRequest(string UserId, string? Description) : IRequest<ApiKeyOneTimeViewDTO> { }