using TestProject.DataAccess.Abstraction.Repositories;
using TestProject.Domain.Entities;

namespace TestProject.DataAccess.Repositories;

public class VisitRepository : Repository<Visit, int>, IVisitRepository
{

}