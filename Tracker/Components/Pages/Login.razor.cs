using DataModel.Model;

namespace Tracker.Components.Pages
{
    public partial class Login
    {
        private string? ErrorMessage;

        public Users User { get; set; } = new();

        private async void HandleLogin()
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

