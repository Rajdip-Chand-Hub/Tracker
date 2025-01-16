using DataModel.Model;
namespace DataAccess.Service.Interface
{
    public interface ITransactionService
    {
        // Creating required Methods
        List<Transaction> GetAllTransactions();

        Task<bool> CreateTransaction(Transaction transaction);

        Task<bool> DeleteTransaction(Guid transactionID);

        Task<bool> UpdateTransaction(Guid transactionID, Transaction transaction);

        int allIncome();

        int allExpense();

        int TotalAmount();
    }
}
