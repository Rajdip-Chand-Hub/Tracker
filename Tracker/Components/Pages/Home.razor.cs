namespace Tracker.Components.Pages
{
    public partial class Home
    {
        private bool IslogOut { get; set; } = false;

        private void Logout()
        {
            Nav.NavigateTo("/login");
        }

        private void ShowLogoutConfirmation()
        {
            IslogOut = true;
        }

        private void HideLogoutConfirmation()
        {
            IslogOut = false;
        }
    }
}