using DataAccess.Service.Interface;
using DataModel.Abstractions;
using DataModel.Model;

namespace DataAccess.Service
{
    public class TransactionService : TransactionBase, Interface.ITransactionService
    {
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
            SaveUsers(_transactions);
            return true;
        }

        public async Task<bool> DeleteTransaction(Guid guid)
        {
            var tranID = _transactions.FirstOrDefault(t => t.transactionId == guid);
            if (tranID == null)
                return true;
            _transactions.Remove(tranID);
            SaveUsers(_transactions);
            return true;
        }

        //Get the list of all transaction 
        public List<Transaction> GetAllTransactions()
        {
            return _transactions; //return list of transactions.
        }

        public async Task<bool> UpdateTransaction()
        {

            return true;
        }
    }
}