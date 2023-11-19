using Microsoft.EntityFrameworkCore;
using TestProject.DataAccess.Abstraction.Repositories;
using TestProject.DataAccess.Repositories.Base;
using TestProject.Domain.Entities;

namespace TestProject.DataAccess.Repositories;

public class PartRepository : Repository<Part, int>, IPartRepository
{
    public async Task<Part> GetByIdAsync(int id) =>
        await DbSet.Where(x => x.Id == id)
            .FirstOrDefaultAsync();
}