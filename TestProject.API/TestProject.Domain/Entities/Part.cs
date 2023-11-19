namespace TestProject.Domain.Entities;

public class Part
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public int VisitId { get; set; }

    public Visit? Visit { get; set; }
}