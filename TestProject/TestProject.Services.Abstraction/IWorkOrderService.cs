using TestProject.Domain.Dtos;

namespace TestProject.Services.Abstraction;

public interface IWorkOrderService
{
    Task<List<WorkOrderDto>> GetAll();
}