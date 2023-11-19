namespace TestProject.Domain.Options;

public class DatabaseOptions
{
    public const string SqlDbName = "SqlDataBase";

    public string ConnectionString { get; set; } = string.Empty;
}