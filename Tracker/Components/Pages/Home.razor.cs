namespace Tracker.Components.Pages
{
    public partial class Home
    {
        private bool IslogOut { get; set; } = false;  // Property to track logout

        private void Logout() // Method to handle logout
        {
            Nav.NavigateTo("/login");
        }

        private void ShowLogoutConfirmation() // Method to show the logout confirmation
        {
            IslogOut = true;
        }

        private void HideLogoutConfirmation() // Method to hide the logout confirmation
        {
            IslogOut = false;
        }
    }
}