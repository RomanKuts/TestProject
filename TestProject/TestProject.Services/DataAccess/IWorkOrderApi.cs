using Refit;
using TestProject.Domain.Dtos;

namespace TestProject.Services.DataAccess;

public interface IWorkOrderApi
{
    [Get("/api/WorkOrder/all")]
    Task<ApiResponse<List<WorkOrderDto>>> GetAllAsync();

    [Post("/api/WorkOrder")]
    Task CreateAsync([Body] WorkOrderDto workOrderDto);

    [Put("/api/WorkOrder/{id}")]
    Task UpdateAsync(int id, [Body] WorkOrderDto workOrderDto);

    [Delete("/api/WorkOrder/{id}")]
    Task DeleteAsync(int id);
}