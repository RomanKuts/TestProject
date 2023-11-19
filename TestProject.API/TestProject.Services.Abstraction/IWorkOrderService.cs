using TestProject.Domain.Dtos;

namespace TestProject.Services.Abstraction;

public interface IWorkOrderService
{
    Task<List<WorkOrderDto>> GetAllAsync();

    Task CreateAsync(WorkOrderDto workOrderDto);

    Task UpdateAsync(int id, WorkOrderDto workOrderDto);

    Task DeleteAsync(int id);
}