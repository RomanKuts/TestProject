using TestProject.Domain.Dtos;

namespace TestProject.UI.Pages.WorkOrderList.Components.Notification;

public partial class Notification
{
    private string ModalDisplay = "none;";

    private string ModalClass = "";

    private bool ShowBackdrop = false;

    public void Open(WorkOrderDto? workOrder = null)
    {
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

        StateHasChanged();
    }
}