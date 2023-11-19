using Refit;
using TestProject.Domain.Dtos;
using TestProject.Services.DataAccess;

namespace TestProject.Services;

public class WorkOrderService
{
    private readonly IWorkOrderApi _workOrderApi;

    public WorkOrderService(IWorkOrderApi workOrderApi)
    {
        _workOrderApi = workOrderApi;
    }

    public Task<ApiResponse<List<WorkOrderDto>>> GetAllAsync() =>
        _workOrderApi.GetAllAsync();

    public Task CreateAsync(WorkOrderDto workOrderDto) =>
        _workOrderApi.CreateAsync(workOrderDto);

    public Task UpdateAsync(int id, WorkOrderDto workOrderDto) =>
        _workOrderApi.UpdateAsync(id, workOrderDto);

    public Task DeleteAsync(int id) =>
        _workOrderApi.DeleteAsync(id);
}