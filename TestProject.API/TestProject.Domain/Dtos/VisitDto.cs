namespace TestProject.Domain.Dtos;

public class VisitDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int WorkOrderId { get; set; }

    public List<PartDto> Parts { get; set; } = new();
}