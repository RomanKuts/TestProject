using Microsoft.EntityFrameworkCore;
using TestProject.DataAccess.Abstraction.Repositories;
using TestProject.DataAccess.Repositories.Base;
using TestProject.Domain.Entities;

namespace TestProject.DataAccess.Repositories;

public class WorkOrderRepository : Repository<WorkOrder, int>, IWorkOrderRepository
{
    public async Task<WorkOrder> GetByIdAsync(int id) =>
        await DbSet.Where(x => x.Id == id)
            .Include(y => y.Visits)
                .ThenInclude(z => z.Parts)
            .FirstOrDefaultAsync();
}