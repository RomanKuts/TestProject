using AutoMapper;
using TestProject.Domain.Dtos;
using TestProject.Domain.Entities;

namespace TestProject.API.MappingProfiles;

public class WorkOrderMappingProfile : Profile
{
    public WorkOrderMappingProfile()
    {
        CreateMap<WorkOrder, WorkOrderDto>()
            .ReverseMap();
    }
}