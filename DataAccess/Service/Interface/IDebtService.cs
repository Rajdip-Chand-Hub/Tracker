

using DataModel.Model;

namespace DataAccess.Service.Interface
{
    public interface IDebtService
    {
        List<Debt> GetAllDebt();

        Task<bool> CreateDebt(Debt debt);

        Task<bool> DeleteDebt(Guid debtId);

        Task<bool> UpdateDebt(Guid debtId, Debt debt);

        Task<bool> ClearDebt(Guid debtId);

        int PendingDebt();

        int ClearedDebt();
    }
}
