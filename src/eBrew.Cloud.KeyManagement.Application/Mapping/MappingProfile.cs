using AutoMapper;
using eBrew.Cloud.KeyManagement.Application.Dtos;
using eBrew.Cloud.KeyManagement.Entities;

namespace eBrew.Cloud.KeyManagement.Application.Mapping;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ApiKey, ApiKeyOneTimeViewDTO>();
    }
}