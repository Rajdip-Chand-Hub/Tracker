
using DataModel.Model;

namespace Tracker.Components.Pages
{
    public partial class DebtPage
    {
        private string? ErrorMessage;

        private string? InsufficientBalance;

        public Debt debt { get; set; } = new();

        private void backDebt()
        {
            Nav.NavigateTo("/debtmain");
        }

        private async void DebtSubmit()
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