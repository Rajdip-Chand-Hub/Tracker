using Microsoft.AspNetCore.Components;
using DataModel.Model;

namespace Tracker.Components.Pages
{
    public partial class UpdateTransaction : ComponentBase
    {

        [Parameter]
        public Guid transactionId { get; set; } // Captures the route parameter

        private Transaction transaction { get; set; } = new();

        protected override async void OnInitialized()
        {
            transaction = TransactionService.GetAllTransactions()
                           .FirstOrDefault(t => t.transactionId == transactionId) ?? new Transaction();
        }

        private async Task UpdateForm()
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
