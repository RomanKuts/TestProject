using TestProject.DataAccess.Abstraction.Repositories.Base;
using TestProject.Domain.Entities;

namespace TestProject.DataAccess.Abstraction.Repositories;

public interface IWorkOrderRepository : IRepository<WorkOrder, int>
{

}