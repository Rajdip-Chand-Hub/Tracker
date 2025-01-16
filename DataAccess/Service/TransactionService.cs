using DataAccess.Service.Interface;
using DataModel.Abstractions;
using DataModel.Model;
using MudBlazor.Interfaces;


namespace DataAccess.Service
{
    public class TransactionService : TransactionBase, ITransactionService // Inherits TransactionBase and implement ITransactionService interface
    {

        public static int TotalIncome, TotalExpense, Amount; // Static fields to store inflows, outflows and 

        private List<Transaction> _transactions; // Holds lists of transactions


        public TransactionService() // Initializing Constructor
        {
            _transactions = LoadTransaction();
        }

        public async Task<bool> CreateTransaction(Transaction transaction) // Method to create new transaction
        {
            _transactions.Add(new Transaction { transactionId = Guid.NewGuid(), balance = transaction.balance, source = transaction.source,
            transactionType = transaction.transactionType, tag = transaction.tag, remark = transaction.remark});
            SaveTransaction(_transactions); // Saves tbe updated debt list
            return true;
        }

        public async Task<bool> DeleteTransaction(Guid transactionId) // Method to delete a debt by its ID
        {
            var tranID = _transactions.FirstOrDefault(t => t.transactionId == transactionId);
            if (tranID == null)
                return true;
            _transactions.Remove(tranID); // Removes debt with the given ID
            SaveTransaction(_transactions); // Save updated transaction list
            return true;
        }

        
        public List<Transaction> GetAllTransactions() //Get the list of all transaction 
        {
            return _transactions; //return list of transactions.
        }

        public async Task<bool> UpdateTransaction(Guid transactionID, Transaction transaction) // Method to update a debt by its ID
        {
            var UpdateID = _transactions.FirstOrDefault(up => up.transactionId == transactionID); 
            if (UpdateID != null) 
            { 
                UpdateID.balance = transaction.balance;
                UpdateID.source = transaction.source;
                UpdateID.transactionType = transaction.transactionType;
                UpdateID.tag = transaction.tag;
                UpdateID.remark = transaction.remark;
                SaveTransaction(_transactions); // Save the updated transaction list
                return true;
            }
            return false;
        }
        public int allIncome() // Method to calculate total inflows
        {
            var transaction = GetAllTransactions(); // Filters transaction based on transaction type Credit and sum their balances
            return TotalIncome = transaction.Where(t => t.transactionType == TransactionType.Credit).Sum(t => t.balance); 
            
        }
        public int allExpense() // Method to calculate total outflows
        {
            var transaction = GetAllTransactions(); // Filters transaction based on transaction type Debit and sum their balances
            return TotalExpense = transaction.Where(t => t.transactionType == TransactionType.Debit).Sum(t => t.balance);

        }
        public int TotalAmount() // Method to calculate total amount
        {
            var transaction = GetAllTransactions();
            return Amount = TotalIncome - TotalExpense;

        }
    }
}