using DataAccess.Service;
using DataModel.Model;
using Microsoft.AspNetCore.Components;

namespace Tracker.Components.Pages
{
    public partial class UpdateDebt : ComponentBase
    {
        [Parameter] // Parameter to accept the unique identifier for the debt to be updated.
        public Guid debtId {  get; set; } 

        private Debt debt {  get; set; } = new(); // Instance of the Debt object to hold the data of the selected debt.

        protected override async void OnInitialized() // Initializing components
        {
            debt = DebtService.GetAllDebt()  // Fetch the specific debt record by matching the provided debtId.
                .FirstOrDefault (db => db.debtId == debtId) ?? new Debt(); // Fallback to a new Debt object if not found.

        }
        private async Task UpdateForm() // Method to update debt form
        {
            var update = await DebtService.UpdateDebt(debtId, debt);
            Nav.NavigateTo("/debtmain");
        }
        private void backHome()
        {
            Nav.NavigateTo("/debtmain");
        }
    }
}