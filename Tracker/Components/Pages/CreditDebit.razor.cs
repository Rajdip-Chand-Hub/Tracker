using DataModel.Model;

namespace Tracker.Components.Pages
{
    public partial class CreditDebit
    {
        private string? ErrorMessage;

        public Transaction transaction { get; set; } = new();
        private async void Submit()
        {
            if (await TransactionService.CreateTransaction(transaction))
            {
                Nav.NavigateTo("/main");
            }
            else
            {
                ErrorMessage = "Invalid Input";
            }

        }
    }
}