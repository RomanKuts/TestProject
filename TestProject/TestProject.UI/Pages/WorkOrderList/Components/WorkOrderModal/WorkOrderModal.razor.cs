using Microsoft.AspNetCore.Components;
using TestProject.Domain.Dtos;
using TestProject.Services;

namespace TestProject.UI.Pages.WorkOrderList.Components.WorkOrderModal;

public partial class WorkOrderModal
{
    [Inject]
    private WorkOrderService WorkOrderService { get; set; } = default!;

    [Parameter]
    public EventCallback DatabaseChanged { get; set; }

    public WorkOrderDto WorkOrder { get; set; } = new();

    private string ModalDisplay = "none;";

    private string ModalClass = "";

    private bool ShowBackdrop = false;

    public void Open(WorkOrderDto? workOrder = null)
    {
        if (workOrder is not null)
        {
            WorkOrder = workOrder;
        }

        ModalDisplay = "block;";
        ModalClass = "Show";
        ShowBackdrop = true;

        StateHasChanged();
    }

    private void Close()
    {
        ModalDisplay = "none";
        ModalClass = "";
        ShowBackdrop = false;

        WorkOrder = new();

        StateHasChanged();
    }

    private async Task OnClickHandler()
    {
        if (WorkOrder.Id.HasValue)
        {
            await WorkOrderService.UpdateAsync(WorkOrder.Id.Value, WorkOrder);
        }
        else
        {
            await WorkOrderService.CreateAsync(WorkOrder);
        }

        Close();

        await DatabaseChanged.InvokeAsync();
    }
}