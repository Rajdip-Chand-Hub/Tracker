using DataModel.Model;

namespace Tracker.Components.Pages
{
    public partial class CreditDebit
    {
        private string? ErrorMessage;

        private string? InsufficientBalance;

        public Transaction transaction { get; set; } = new();

        private void backTransaction()
        {
            Nav.NavigateTo("/main");
        }

        protected override async Task OnInitializedAsync()
        {
            totalAmount = TransactionService.TotalAmount();
        }
        private int totalAmount;
        private async void Submit()
        {
            if (TransactionType.Debit == transaction.transactionType)
            {
                if (totalAmount >= transaction.balance)
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
                else
                {
                    InsufficientBalance = "Not Sufficient Balance";
                }
            }
            else 
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
}