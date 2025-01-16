using DataModel.Model;
using Microsoft.AspNetCore.Components;

namespace Tracker.Components.Pages
{
    public partial class DebtMain : ComponentBase
    {
        // Flags to control sorting and filtering behavior.
        private bool isAsc = true;
        private bool isFilter = true;

        private List<Debt> debt = new(); // The main list displayed on the UI.
        private List<Debt> debts = new(); // A backup list for resetting or filtering.

        private string Message = string.Empty;

        protected override void OnInitialized() // Initializing components
        {
            debt = DebtService.GetAllDebt();
            debts = DebtService.GetAllDebt();
        }
        private void addDebt()
        {
            Nav.NavigateTo("/debtpage");
        }
        private void backHome()
        {
            Nav.NavigateTo("/home");
        }
        private void updateDebt(Guid debtID)
        {
            Nav.NavigateTo($"/updatedebt{debtID}");
        }
       private async Task DebtDelete(Guid debt) // Deletes a debt by ID
        {
            bool result = await DebtService.DeleteDebt(debt);
            Message = result ? "Successfully Deleted" : "Delete Failed";
        }
        private async Task changeStatus(Guid debtId) // Changes status of debt to Cleared by ID
        {
            bool result = await DebtService.ClearDebt(debtId);
        }
        private void sortingTransactionAsc() // Sorts debts based on dateTakken property 
        {
            if (isAsc)
            {
                debt = debt.OrderBy(t => t.debtTakken).ToList(); // Sort debt list in ascending order
                isAsc = false;
            }
            else
            {
                debt = debt.OrderByDescending(t => t.debtTakken).ToList(); // Sort debt list in descending order
                isAsc = true;
            }
        }
        private void fillterTransactions() // Filters debts based on their status (Pending or Cleared).
        {
            if (isFilter)
            {
                debt = debts.Where(f => f.debtStatus == DebtStatus.Pending).ToList(); // Filters the list to show only pending debts
                isFilter = false;
            }
            else
            {
                debt = debts.Where(f => f.debtStatus == DebtStatus.Cleared).ToList(); // Filters the list to show only cleared debts
                isFilter = true;
            }

        }
    }
}