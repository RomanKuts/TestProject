using Microsoft.EntityFrameworkCore;

namespace TestProject.DataAccess.Abstraction.Repositories.Base;

public interface IBaseRepository
{
    void SetContext(DbContext context);
}