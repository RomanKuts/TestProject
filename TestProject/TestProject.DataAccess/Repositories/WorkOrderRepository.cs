using TestProject.DataAccess.Abstraction.Repositories;
using TestProject.Domain.Entities;

namespace TestProject.DataAccess.Repositories;

public class WorkOrderRepository : Repository<WorkOrder, int>, IWorkOrderRepository
{

}