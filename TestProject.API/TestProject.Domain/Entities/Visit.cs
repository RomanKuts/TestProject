namespace TestProject.Domain.Entities;

public class Visit
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int WorkOrderId { get; set; }

    public WorkOrder? WorkOrder { get; set; }

    public List<Part>? Parts { get; set; }
}