using Microsoft.EntityFrameworkCore;
using TestProject.DataAccess.Abstraction.Repositories;
using TestProject.DataAccess.Repositories.Base;
using TestProject.Domain.Entities;

namespace TestProject.DataAccess.Repositories;

public class VisitRepository : Repository<Visit, int>, IVisitRepository
{
    public async Task<Visit> GetByIdAsync(int id) =>
        await DbSet.Where(x => x.Id == id)
            .Include(y => y.Parts)
            .FirstOrDefaultAsync();
}