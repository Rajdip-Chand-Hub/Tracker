using DataModel.Model;

namespace Tracker.Components.Pages
{
    public partial class Login
    {
        private string? ErrorMessage; // Stores error message 

        public Users User { get; set; } = new(); // Public property to hold the user details

        private async void HandleLogin() // Method to handle user login
        {
            if (UserService.Login(User))
            {
                Nav.NavigateTo("/home");
            }
            else
            {
                ErrorMessage = "Invalid username or password";
            }

        }

    }

}

