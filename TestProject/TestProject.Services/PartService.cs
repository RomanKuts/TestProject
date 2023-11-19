using Refit;
using TestProject.Domain.Dtos;
using TestProject.Services.DataAccess;

namespace TestProject.Services;

public class PartService
{
    private readonly IPartApi _partApi;

    public PartService(IPartApi partApi)
    {
        _partApi = partApi;
    }

    public Task<ApiResponse<List<PartDto>>> GetAllAsync() =>
        _partApi.GetAllAsync();

    public Task<IApiResponse> CreateAsync(PartDto partDto) =>
        _partApi.CreateAsync(partDto);

    public Task UpdateAsync(int id, PartDto partDto) =>
        _partApi.UpdateAsync(id, partDto);

    public Task DeleteAsync(int id) =>
        _partApi.DeleteAsync(id);
}