using Refit;
using TestProject.Domain.Dtos;

namespace TestProject.Services.DataAccess;

public interface IPartApi
{
    [Get("/api/Part/all")]
    Task<ApiResponse<List<PartDto>>> GetAllAsync();

    [Post("/api/Part")]
    Task<IApiResponse> CreateAsync([Body] PartDto partDto);

    [Put("/api/Part/{id}")]
    Task UpdateAsync(int id, [Body] PartDto partDto);

    [Delete("/api/Part/{id}")]
    Task DeleteAsync(int id);
}