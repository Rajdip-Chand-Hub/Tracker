using DataModel.Model;
using Microsoft.AspNetCore.Components;

namespace Tracker.Components.Pages
{
    public partial class DebtMain : ComponentBase
    {
        private bool isAsc = true;
        private bool isFilter = true;

        private List<Debt> debt = new();
        private List<Debt> debts = new();

        private string Message = string.Empty;

        protected override void OnInitialized()
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
       private async Task DebtDelete(Guid debt)
        {
            bool result = await DebtService.DeleteDebt(debt);
            Message = result ? "Successfully Deleted" : "Delete Failed";
        }
        private async Task changeStatus(Guid debtId)
        {
            bool result = await DebtService.ClearDebt(debtId);
        }
        private void sortingTransactionAsc()
        {
            if (isAsc)
            {
                debt = debt.OrderBy(t => t.debtTakken).ToList();
                isAsc = false;
            }
            else
            {
                debt = debt.OrderByDescending(t => t.debtTakken).ToList();
                isAsc = true;
            }
        }
        private void fillterTransactions()
        {
            if (isFilter)
            {
                debt = debts.Where(f => f.debtStatus == DebtStatus.Pending).ToList();
                isFilter = false;
            }
            else
            {
                debt = debts.Where(f => f.debtStatus == DebtStatus.Cleared).ToList();
                isFilter = true;
            }

        }
    }
}