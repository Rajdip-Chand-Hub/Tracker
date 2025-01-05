using Microsoft.AspNetCore.Components;
using DataModel.Model;


namespace Tracker.Components.Pages
{
    public partial class Main : ComponentBase
    {
        private List<Transaction> transaction = new List<Transaction>();

        private string Message = string.Empty;

        private bool IslogOut { get; set; } = false;
        protected override void OnInitialized()
        {
            GetAllTransactions();
        }
        private void Logout()
        {
            Nav.NavigateTo("/login");
        }

        private async Task<List<Transaction>> GetAllTransactions()
        {
            try
            {
                transaction = TransactionService.GetAllTransactions();

                return transaction;

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        private async Task DeleteTransaction(Guid transaction)
        {
            bool result = await TransactionService.DeleteTransaction(transaction);

            Message = result ? "Successfully Deleted" : "Error Deleting User";
        }

        private void ShowLogoutConfirmation()
        {
            IslogOut = true;
        }

        private void HideLogoutConfirmation()
        {
            IslogOut = false;
        }
    }

}