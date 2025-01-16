using DataModel.Model;

namespace Tracker.Components.Pages
{
    public partial class Dashboard
    {
        private List<Transaction> transaction = new();

        private double[] pieData;
        private string[] pieLabel;
        private double[] pieDataDebit;
        private string[] pieLabelDebit;

        protected override async Task OnInitializedAsync() {
            totalIncome = TransactionService.allIncome();
            totalExpense = TransactionService.allExpense();
            totalAmount = TransactionService.TotalAmount();
            pendingDebts = DebtService.PendingDebt();
            clearedDebts = DebtService.ClearedDebt();
            total = calculateTotalAmount();
            transaction = TransactionService.GetAllTransactions();
            TopFiveCredits();
            TopFiveDebits();
        }
        private int totalIncome, totalExpense, totalAmount, pendingDebts, clearedDebts, total;

        private int calculateTotalAmount()
        {
            var total = totalAmount+pendingDebts;
            return total;
        }
        private void TopFiveCredits()
        {
            var top5= transaction.Where(t=>t.transactionType == TransactionType.Credit).OrderByDescending(t=>t.balance).Take(5).ToList();
            pieData = top5.Select(t=>(double)t.balance).ToArray();
            pieLabel = top5.Select(t => $"{t.transactionType} Amount: {t.balance}").ToArray();
        }

        private void TopFiveDebits()
        {
            var top5 = transaction.Where(t => t.transactionType == TransactionType.Debit).OrderByDescending(t => t.balance).Take(5).ToList();
            pieDataDebit = top5.Select(t => (double)t.balance).ToArray();
            pieLabelDebit = top5.Select(t => $"{t.transactionType} Amount: {t.balance}").ToArray();
        }
        private void backHome()
        {
            Nav.NavigateTo("/home");
        }

    }
}