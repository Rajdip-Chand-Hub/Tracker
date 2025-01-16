using DataAccess.Service.Interface;
using DataModel.Abstractions;
using DataModel.Model;
using MudBlazor.Interfaces;


namespace DataAccess.Service
{
    public class TransactionService : TransactionBase, ITransactionService
    {

        public static int TotalIncome, TotalExpense, Amount;
        // Load all transaction from jason file and store it in the list of _transactions.
        private List<Transaction> _transactions;

        public TransactionService() 
        {
            _transactions = LoadTransaction();// Load the list of transaction from the JSON file.
        }

        public async Task<bool> CreateTransaction(Transaction transaction)
        {
            _transactions.Add(new Transaction { transactionId = Guid.NewGuid(), balance = transaction.balance, source = transaction.source,
            transactionType = transaction.transactionType, tag = transaction.tag, remark = transaction.remark});
            SaveTransaction(_transactions);
            return true;
        }

        public async Task<bool> DeleteTransaction(Guid transactionId)
        {
            var tranID = _transactions.FirstOrDefault(t => t.transactionId == transactionId);
            if (tranID == null)
                return true;
            _transactions.Remove(tranID);
            SaveTransaction(_transactions);
            return true;
        }

        //Get the list of all transaction 
        public List<Transaction> GetAllTransactions()
        {
            return _transactions; //return list of transactions.
        }

        public async Task<bool> UpdateTransaction(Guid transactionID, Transaction transaction)
        {
            var UpdateID = _transactions.FirstOrDefault(up => up.transactionId == transactionID);
            if (UpdateID != null) 
            { 
                UpdateID.balance = transaction.balance;
                UpdateID.source = transaction.source;
                UpdateID.transactionType = transaction.transactionType;
                UpdateID.tag = transaction.tag;
                UpdateID.remark = transaction.remark;
                SaveTransaction(_transactions);
                return true;
            }
            return false;
        }
        public int allIncome()
        {
            var transaction = GetAllTransactions();
            return TotalIncome = transaction.Where(t => t.transactionType == TransactionType.Credit).Sum(t => t.balance);
            
        }
        public int allExpense()
        {
            var transaction = GetAllTransactions();
            return TotalExpense = transaction.Where(t => t.transactionType == TransactionType.Debit).Sum(t => t.balance);

        }
        public int TotalAmount()
        {
            var transaction = GetAllTransactions();
            return Amount = TotalIncome - TotalExpense;

        }
    }
}