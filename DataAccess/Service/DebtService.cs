
using DataAccess.Service.Interface;
using DataModel.Abstractions;
using DataModel.Model;
using System.Transactions;

namespace DataAccess.Service
{
    public class DebtService : DebtBase, IDebtService
    {
        public static int PendingAmount, ClearedAmount;

        private List<Debt> _debts;

        public DebtService()
        {
            _debts = LoadDebt();
        }
        public List<Debt> GetAllDebt()
        {
            return _debts; //return list of transactions.
        }

        public async Task<bool> ClearDebt(Guid debtId)
        {
            var clearDebtID = _debts.FirstOrDefault(ud => ud.debtId == debtId);
            if (clearDebtID != null)
            {
                clearDebtID.debtStatus = DebtStatus.Cleared;
                SaveDebt(_debts);
                return true;
            }
            return false;
        }

        public async Task<bool> CreateDebt(Debt debt)
        {
            _debts.Add(new Debt
            {
                debtId = Guid.NewGuid(),
                debtBalance = debt.debtBalance,
                debtSource = debt.debtSource,
                debtTag = debt.debtTag,
                debtStatus = debt.debtStatus,
                debtRemark = debt.debtRemark,
                debtTakken = debt.debtTakken,
                debtDue = debt.debtDue,
            });
            SaveDebt(_debts);
            return true;
        }

        public async Task<bool> DeleteDebt(Guid debtId)
        {
            var debtID = _debts.FirstOrDefault(d =>  d.debtId == debtId);
            if (debtID == null)
                return true;
            _debts.Remove(debtID);
            SaveDebt(_debts);
            return true;
        }

        public async Task<bool> UpdateDebt(Guid debtId, Debt debt)
        {
            var updateDebtID = _debts.FirstOrDefault( ud => ud.debtId == debtId);
            if (updateDebtID != null)
            {
                updateDebtID.debtBalance = debt.debtBalance;
                updateDebtID.debtSource = debt.debtSource;
                updateDebtID.debtTag = debt.debtTag;
                updateDebtID.debtStatus = debt.debtStatus;
                updateDebtID.debtRemark = debt.debtRemark;
                updateDebtID.debtTakken = debt.debtTakken;
                updateDebtID.debtDue = debt.debtDue;
                SaveDebt(_debts);
                return true;
            }
            return false;
        }
        public int PendingDebt()
        {
            var debtAmount = GetAllDebt();
            return PendingAmount = debtAmount.Where(dA => dA.debtStatus == DebtStatus.Pending).Sum(dA => dA.debtBalance);
        }
        public int ClearedDebt()
        {
            var debtAmount = GetAllDebt();
            return ClearedAmount = debtAmount.Where(dA => dA.debtStatus == DebtStatus.Cleared).Sum(dA => dA.debtBalance);
        }
    }
}
