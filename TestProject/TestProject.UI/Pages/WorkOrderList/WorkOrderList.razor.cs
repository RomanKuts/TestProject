using Microsoft.AspNetCore.Components;
using TestProject.Domain.Dtos;
using TestProject.Services;
using TestProject.UI.Pages.WorkOrderList.Components.Notification;
using TestProject.UI.Pages.WorkOrderList.Components.WorkOrderModal;

namespace TestProject.UI.Pages.WorkOrderList;

public partial class WorkOrderList
{
    [Inject]
    private WorkOrderService WorkOrderService { get; set; } = default!;

    private List<WorkOrderDto> WorkOrders { get; set; } = new();

    private WorkOrderModal ModalRef { get; set; } = default!;

    private Notification NotificationRef { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        await GetAllWorkOrdersAsync();

        await base.OnInitializedAsync();
    }

    private void OnCreateHandler()
    {
        ModalRef.Open();
    }

    private void OnUpdateHandler(WorkOrderDto workOrder)
    {
        ModalRef.Open(workOrder);
    }

    private async Task OnDeleteHandler(int id)
    {
        await WorkOrderService.DeleteAsync(id);

        NotificationRef.Open();

        await GetAllWorkOrdersAsync();
    }

    private async Task DatabaseChangedHandler()
    {
        NotificationRef.Open();

        await GetAllWorkOrdersAsync();
    }

    private async Task GetAllWorkOrdersAsync()
    {
        var response = await WorkOrderService.GetAllAsync();

        if (response.IsSuccessStatusCode && response.Content is not null)
        {
            WorkOrders = response.Content;
        }

        StateHasChanged();
    }
}