using TestProject.Domain.Dtos;

namespace TestProject.Services.Abstraction;

public interface IPartService
{
    Task<List<PartDto>> GetAllAsync();

    Task CreateAsync(PartDto partDto);

    Task UpdateAsync(int id, PartDto partDto);

    Task DeleteAsync(int id);
}