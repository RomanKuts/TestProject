using Refit;
using TestProject.Domain.Dtos;

namespace TestProject.Services.DataAccess;

public interface IVisitApi
{
    [Get("/api/Visit/all")]
    Task<ApiResponse<List<VisitDto>>> GetAllAsync();

    [Post("/api/Visit")]
    Task<IApiResponse> CreateAsync([Body] VisitDto visitDto);

    [Put("/api/Visit/{id}")]
    Task<IApiResponse> UpdateAsync(int id, [Body] VisitDto visitDto);

    [Delete("/api/Visit/{id}")]
    Task DeleteAsync(int id);
}