using TestProject.Domain.Dtos;

namespace TestProject.Services.Abstraction;

public interface IVisitService
{
    Task<List<VisitDto>> GetAllAsync();

    Task CreateAsync(VisitDto visitDto);

    Task UpdateAsync(int id, VisitDto visitDto);

    Task DeleteAsync(int id);
}