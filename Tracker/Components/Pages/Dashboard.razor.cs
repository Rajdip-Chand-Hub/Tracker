using DataModel.Model;

namespace Tracker.Components.Pages
{
    public partial class Dashboard
    {
        private List<Transaction> transaction = new(); // list to store all transactions

        // Arrays to hold data
        private double[] pieData;
        private string[] pieLabel;
        private double[] pieDataDebit;
        private string[] pieLabelDebit;

        protected override async Task OnInitializedAsync() //Initializating components
        {
            // Fetches total total income, total expense, and current balance from the TransactionService.
            totalIncome = TransactionService.allIncome();
            totalExpense = TransactionService.allExpense();
            totalAmount = TransactionService.TotalAmount();
            // Fetches pending and cleared debt amounts from the DebtService.
            pendingDebts = DebtService.PendingDebt();
            clearedDebts = DebtService.ClearedDebt();
            // Calculates the overall total amount
            total = calculateTotalAmount();
            transaction = TransactionService.GetAllTransactions();
            // Calculates data and labels for pie charts of top 5 credits and debits.
            TopFiveCredits();
            TopFiveDebits();
        }
        private int totalIncome, totalExpense, totalAmount, pendingDebts, clearedDebts, total; // Fields to store financial statistics

        private int calculateTotalAmount() // Method to calculate overall total amount
        {
            var total = totalAmount+pendingDebts;
            return total; 
        }
        private void TopFiveCredits() // Method to calculate data and labels for the top 5 debit transactions.
        {
            // Filters transactions of type 'Credit', orders them by balance (descending), and takes the top 5.
            var top5 = transaction.Where(t=>t.transactionType == TransactionType.Credit).OrderByDescending(t=>t.balance).Take(5).ToList();
            // Extracts balances and labels for the top 5 credits.
            pieData = top5.Select(t=>(double)t.balance).ToArray();
            pieLabel = top5.Select(t => $"{t.transactionType} Amount: {t.balance}").ToArray();
        }

        private void TopFiveDebits()
        {
            // Filters transactions of type 'Debit', orders them by balance (descending), and takes the top 5.
            var top5 = transaction.Where(t => t.transactionType == TransactionType.Debit).OrderByDescending(t => t.balance).Take(5).ToList();
            // Extracts balances and labels for the top 5 debits.
            pieDataDebit = top5.Select(t => (double)t.balance).ToArray();
            pieLabelDebit = top5.Select(t => $"{t.transactionType} Amount: {t.balance}").ToArray();
        }
        private void backHome()
        {
            Nav.NavigateTo("/home");
        }

    }
}