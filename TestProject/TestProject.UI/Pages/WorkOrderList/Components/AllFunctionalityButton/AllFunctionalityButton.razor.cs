using Microsoft.AspNetCore.Components;
using TestProject.Domain.Dtos;
using TestProject.Services;

namespace TestProject.UI.Pages.WorkOrderList.Components.AllFunctionalityButton;

partial class AllFunctionalityButton
{
    [Inject]
    private WorkOrderService WorkOrderService { get; set; } = default!;

    [Inject]
    private VisitService VisitService { get; set; } = default!;

    [Inject]
    private PartService PartService { get; set; } = default!;

    [Parameter]
    public List<WorkOrderDto> WorkOrders { get; set; } = new();

    [Parameter]
    public EventCallback DatabaseChanged { get; set; }

    private async Task OnButtonClick()
    {
        await Delete5RandomWorkOrders();
        await Delete5RandomVisits();
        await Delete5RandomParts();
        await Change5RandomParts();

        await DatabaseChanged.InvokeAsync();
    }

    private async Task Delete5RandomWorkOrders()
    {
        int count = WorkOrders.Count < 5 ? WorkOrders.Count : 5;

        if (count == 0)
        {
            return;
        }

        for (int i = 0; i < count; i++)
        {
            var index = Random.Shared.Next(0, WorkOrders.Count);

            await WorkOrderService.DeleteAsync(WorkOrders[index].Id.Value);

            var response = await WorkOrderService.GetAllAsync();
            WorkOrders = response.Content!;
        }
    }

    private async Task Delete5RandomVisits()
    {
        var response = await VisitService.GetAllAsync();
        var visits = response.Content!;

        int count = visits.Count < 5 ? visits.Count : 5;

        if (count == 0)
        {
            return;
        }

        for (int i = 0; i < count; i++)
        {
            var index = Random.Shared.Next(0, visits.Count - 1);

            await VisitService.DeleteAsync(visits[index].Id);

            response = await VisitService.GetAllAsync();
            visits = response.Content!;
        }
    }

    private async Task Delete5RandomParts()
    {
        var response = await PartService.GetAllAsync();
        var parts = response.Content!;

        int count = parts.Count < 5 ? parts.Count : 5;

        if (count == 0)
        {
            return;
        }

        for (int i = 0; i < count; i++)
        {
            var index = Random.Shared.Next(0, parts.Count - 1);

            await PartService.DeleteAsync(parts[index].Id);

            response = await PartService.GetAllAsync();
            parts = response.Content!;
        }
    }

    private async Task Change5RandomParts()
    {
        var response = await PartService.GetAllAsync();
        var parts = response.Content!;

        int count = parts.Count < 5 ? parts.Count : 5;

        if (count == 0)
        {
            return;
        }

        for (int i = 0; i < count; i++)
        {
            var index = Random.Shared.Next(0, parts.Count - 1);

            var part = parts[index];

            part.Quantity = Random.Shared.Next(0, 10);
            part.Price = Random.Shared.Next(0, 100);

            await PartService.UpdateAsync(part.Id, part);
        }
    }
}