using DataModel.Model;

namespace Tracker.Components.Pages
{
    public partial class CreditDebit // Partial class of CreditDebit component
    {
        private string? ErrorMessage; // Private field to store error message

        private string? InsufficientBalance; // Private field to store insufficient balance message

        public Transaction transaction { get; set; } = new(); // Public property to hold the transaction details

        private void backTransaction() // Method to navigate to main page
        {
            Nav.NavigateTo("/main");
        }

        protected override async Task OnInitializedAsync() // Initializing components
        {
            totalAmount = TransactionService.TotalAmount();
        }
        private int totalAmount;
        private async void Submit() // Method to handle submission of transaction
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