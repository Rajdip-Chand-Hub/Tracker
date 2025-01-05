using DataModel.Model;
namespace DataAccess.Service.Interface
{
    public interface ITransactionService
    {
        List<Transaction> GetAllTransactions();

        Task<bool> CreateTransaction(Transaction transaction);

        Task<bool> DeleteTransaction(Guid transaction);

        Task<bool> UpdateTransaction();
    }
}
