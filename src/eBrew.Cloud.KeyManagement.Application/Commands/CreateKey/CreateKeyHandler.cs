using AutoMapper;
using eBrew.Cloud.KeyManagement.Application.Dtos;
using eBrew.Cloud.KeyManagement.Entities;
using eBrew.Cloud.KeyManagement.Infrastructure;
using MediatR;

namespace eBrew.Cloud.KeyManagement.Application.Commands.CreateKey;

public sealed class CreateKeyHandler(KeyManagementContext context, IMapper mapper) : IRequestHandler<CreateKeyRequest, ApiKeyOneTimeViewDTO>
{
    private readonly KeyManagementContext _context = context;
    private readonly IMapper _mapper = mapper;
    
    public async Task<ApiKeyOneTimeViewDTO> Handle(CreateKeyRequest request, CancellationToken cancellationToken)
    {
        var apiKey = (await _context.AddAsync(new ApiKey(request.UserId, Extensions.GetSecretKey(), request.Description))).Entity;

        return _mapper.Map<ApiKeyOneTimeViewDTO>(apiKey);
    }
}