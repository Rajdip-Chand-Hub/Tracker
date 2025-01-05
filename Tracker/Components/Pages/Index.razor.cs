using Microsoft.AspNetCore.Components;

namespace Tracker.Components.Pages
{
    public partial class Index : ComponentBase
    {
        protected override void OnInitialized()
        {
            Nav.NavigateTo("/login");
        }
    }
}