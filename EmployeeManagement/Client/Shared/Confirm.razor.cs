using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Client.Shared
{
    public class ConfirmBase : ComponentBase
    {
        protected bool ShowConfirmation { get; set; }

        [Parameter]
        public string ConfirmationTitle { get; set; } = "Confirm Delete";
        public string ConfirmationMessage { get; set; } = "Are You sure to delete the item?";

        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool>          ConfirmationChanged { get; set; }

        protected async Task OnConfirmationChange(bool value)
        {
            ShowConfirmation = false;
            await OnConfirmationChange(value);
        }

    }
}
