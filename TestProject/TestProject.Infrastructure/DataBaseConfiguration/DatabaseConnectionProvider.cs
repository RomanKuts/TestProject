namespace TestProject.Infrastructure.DataBaseConfiguration;

public class DatabaseConnectionProvider : IDatabaseConnectionProvider
{
    private readonly IConfigurationManager configurationManager;

    public DatabaseConnectionProvider(IConfigurationManager configurationManager)
    {
        this.configurationManager = configurationManager;
    }

    public string GetDatabaseConnectionString()
    {
        return this.configurationManager.DatabaseConnectionString;
    }
}