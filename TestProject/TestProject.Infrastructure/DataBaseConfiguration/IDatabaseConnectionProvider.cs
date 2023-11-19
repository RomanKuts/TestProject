namespace TestProject.Infrastructure.DataBaseConfiguration;

public interface IDatabaseConnectionProvider
{
    string GetDatabaseConnectionString();
}