
using DataModel.Model;

namespace Tracker.Components.Pages
{
    public partial class DebtPage
    {
        private string? ErrorMessage; // Stores error message

        private string? InsufficientBalance; // Stores insufficient balance message 

        public Debt debt { get; set; } = new(); 

        private void backDebt() 
        {
            Nav.NavigateTo("/debtmain");
        }

        private async void DebtSubmit() // Method to create new debt
        {

            if (await DebtService.CreateDebt(debt))
            {
                Nav.NavigateTo("/debtmain");
            }
            else
            {
                ErrorMessage = "Invalid Input";
            }

        }
    }
}