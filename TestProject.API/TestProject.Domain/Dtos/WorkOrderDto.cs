namespace TestProject.Domain.Dtos;

public class WorkOrderDto
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public List<VisitDto> Visits { get; set; } = new();
}