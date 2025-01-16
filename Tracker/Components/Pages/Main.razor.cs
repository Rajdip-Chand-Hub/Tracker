using Microsoft.AspNetCore.Components;
using DataModel.Model;



namespace Tracker.Components.Pages
{
    public partial class Main : ComponentBase
    {
        private bool isAsc = true;

        private bool isFilter = true;

        private List<Transaction> transaction = new();
        private List<Transaction> transactions = new();

        private string Message = string.Empty;

        private bool IslogOut { get; set; } = false;
        protected override void OnInitialized()
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

        private async Task DeleteTransaction(Guid transaction)
        {
            bool result = await TransactionService.DeleteTransaction(transaction);

            Message = result ? "Successfully Deleted" : "Error Deleting User";
        }
        private void sortingTransactionAsc()
        {
            if(isAsc)
            { 
                transaction = transaction.OrderBy(t => t.created).ToList();
                isAsc = false;
            }
            else
            {
                transaction = transaction.OrderByDescending(t => t.created).ToList();
                isAsc = true;
            }
        }
        private void fillterTransactions()
        {
            if (isFilter)
            {
                transaction = transactions.Where(f => f.transactionType == TransactionType.Credit).ToList();
                isFilter = false;
            }
            else 
            {
                transaction = transactions.Where(f => f.transactionType == TransactionType.Debit).ToList();
                isFilter = true;
            }
            
        }
    }

}