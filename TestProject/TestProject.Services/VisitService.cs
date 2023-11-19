using Refit;
using TestProject.Domain.Dtos;
using TestProject.Services.DataAccess;

namespace TestProject.Services;

public class VisitService
{
    private readonly IVisitApi _visitApi;

    public VisitService(IVisitApi visitApi)
    {
        _visitApi = visitApi;
    }

    public Task<ApiResponse<List<VisitDto>>> GetAllAsync() =>
        _visitApi.GetAllAsync();

    public Task<IApiResponse> CreateAsync(VisitDto visitDto) =>
        _visitApi.CreateAsync(visitDto);

    public Task<IApiResponse> UpdateAsync(int id, VisitDto visitDto) =>
        _visitApi.UpdateAsync(id, visitDto);

    public Task DeleteAsync(int id) =>
        _visitApi.DeleteAsync(id);
}