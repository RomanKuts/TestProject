namespace TestProject.Domain.Entities;

public class WorkOrder
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public List<Visit>? Visits { get; set; }
}