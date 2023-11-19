using TestProject.DataAccess.Abstraction.Repositories.Base;
using TestProject.Domain.Entities;

namespace TestProject.DataAccess.Abstraction.Repositories;

public interface IVisitRepository : IRepository<Visit, int>
{
    Task<Visit> GetByIdAsync(int id);
}