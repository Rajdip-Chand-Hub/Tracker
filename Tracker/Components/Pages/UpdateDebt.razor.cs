using DataAccess.Service;
using DataModel.Model;
using Microsoft.AspNetCore.Components;

namespace Tracker.Components.Pages
{
    public partial class UpdateDebt : ComponentBase
    {
        [Parameter] 
        public Guid debtId {  get; set; }

        private Debt debt {  get; set; } = new();

        protected override async void OnInitialized()
        {
            debt = DebtService.GetAllDebt()
                .FirstOrDefault (db => db.debtId == debtId) ?? new Debt();

        }
        private async Task UpdateForm()
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