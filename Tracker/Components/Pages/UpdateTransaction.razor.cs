using Microsoft.AspNetCore.Components;
using DataModel.Model;

namespace Tracker.Components.Pages
{
    public partial class UpdateTransaction : ComponentBase
    {

        [Parameter]
        public Guid transactionId { get; set; } // Parameter to accept the unique identifier for the transactions to be updated.

        private Transaction transaction { get; set; } = new(); // Instance of the Debt object to hold the data of the selected transactions.

        protected override async void OnInitialized() // Initializing components
        {
            transaction = TransactionService.GetAllTransactions() // Fetch the specific debt record by matching the provided transaction ID.
                           .FirstOrDefault(t => t.transactionId == transactionId) ?? new Transaction(); // Fallback to a new Transaction object if not found.
        }

        private async Task UpdateForm() // Method to update debt form
        {
            var update = await TransactionService.UpdateTransaction(transactionId, transaction);
            Nav.NavigateTo("/main");
        }

        private void backHome()
        {
            Nav.NavigateTo("/main");
        }
    }
}
