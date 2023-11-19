namespace TestProject.DataAccess.Abstraction;

public interface IUnitOfWorkFactory
{
    IUnitOfWork CreateUnitOfWork();
}