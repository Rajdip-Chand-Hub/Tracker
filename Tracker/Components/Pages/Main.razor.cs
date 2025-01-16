using Microsoft.AspNetCore.Components;
using DataModel.Model;



namespace Tracker.Components.Pages
{
    public partial class Main : ComponentBase
    {
        // Flags to control sorting and filtering behavior.
        private bool isAsc = true;
        private bool isFilter = true;

        private List<Transaction> transaction = new(); // The main list displayed on the UI.
        private List<Transaction> transactions = new(); // A backup list for resetting or filtering.

        private string Message = string.Empty;
        protected override void OnInitialized() // Initializing components
        {
            transaction = TransactionService.GetAllTransactions();
            transactions = TransactionService.GetAllTransactions();

        }
        private void addTransaction()
        {
            Nav.NavigateTo("/creditdebit");
        }
        private void NavTransaction(Guid transactionId)
        {
            Nav.NavigateTo($"/updatetransaction{transactionId}");
        }

        private void backHome()
        {
            Nav.NavigateTo("/home");
        }

        private async Task DeleteTransaction(Guid transaction) // Deletes a transactios by ID
        {
            bool result = await TransactionService.DeleteTransaction(transaction);

            Message = result ? "Successfully Deleted" : "Error Deleting User";
        }
        private void sortingTransactionAsc() // Sorts debts based on date property 
        {
            if(isAsc)
            { 
                transaction = transaction.OrderBy(t => t.created).ToList(); // Sort debt list in ascending order
                isAsc = false;
            }
            else
            {
                transaction = transaction.OrderByDescending(t => t.created).ToList(); // Sort debt list in descending order
                isAsc = true;
            }
        }
        private void fillterTransactions() // Filters debts based on transaction type (Credit or Debit)
        {
            if (isFilter)
            {
                transaction = transactions.Where(f => f.transactionType == TransactionType.Credit).ToList(); // Filters the list to show only pending debts
                isFilter = false;
            }
            else 
            {
                transaction = transactions.Where(f => f.transactionType == TransactionType.Debit).ToList(); // Filters the list to show only cleared debts
                isFilter = true;
            }
            
        }
    }

}