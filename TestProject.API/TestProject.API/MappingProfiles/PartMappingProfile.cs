using AutoMapper;
using TestProject.Domain.Dtos;
using TestProject.Domain.Entities;

namespace TestProject.API.MappingProfiles;

public class PartMappingProfile : Profile
{
    public PartMappingProfile()
    {
        CreateMap<Part, PartDto>()
            .ReverseMap();
    }
}