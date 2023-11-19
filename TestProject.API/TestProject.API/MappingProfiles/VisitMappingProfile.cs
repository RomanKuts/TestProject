using AutoMapper;
using TestProject.Domain.Dtos;
using TestProject.Domain.Entities;

namespace TestProject.API.MappingProfiles;

public class VisitMappingProfile : Profile
{
    public VisitMappingProfile()
    {
        CreateMap<Visit, VisitDto>()
            .ReverseMap();
    }
}