using Microsoft.Extensions.Configuration;

namespace TestProject.Infrastructure;

public class ConfigurationManager : IConfigurationManager
{
    private readonly IConfiguration configuration;

    public ConfigurationManager(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public string DatabaseConnectionString => GetConnectionStringValue("quality_sqldb");

    private string GetConnectionStringValue(string connStringName)
    {
        return configuration.GetConnectionString(connStringName);
    }
}