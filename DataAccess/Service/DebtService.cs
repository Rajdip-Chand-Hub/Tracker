
using DataAccess.Service.Interface;
using DataModel.Abstractions;
using DataModel.Model;
using System.Transactions;

namespace DataAccess.Service
{
    public class DebtService : DebtBase, IDebtService // Inherits DebtBase and implement IDebtService interface
    {
        public static int PendingAmount, ClearedAmount; // Static fields to store pending and cleared debt amounts

        private List<Debt> _debts; // Holds lists of debts

        public DebtService() // Initializing Constructor
        {
            _debts = LoadDebt();
        }
        public List<Debt> GetAllDebt() // Get all debts
        {
            return _debts; //return list of debts.
        }

        public async Task<bool> ClearDebt(Guid debtId) // Method to mark a debt as cleare by its ID
        {
            var clearDebtID = _debts.FirstOrDefault(ud => ud.debtId == debtId); // Finds debts with given ID
            if (clearDebtID != null)
            {
                clearDebtID.debtStatus = DebtStatus.Cleared; // Update debt status to Cleared and Save changes
                SaveDebt(_debts);
                return true;
            }
            return false;
        }

        public async Task<bool> CreateDebt(Debt debt) // Method to create new debt
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
            SaveDebt(_debts); // Saves tbe updated debt list
            return true;
        }

        public async Task<bool> DeleteDebt(Guid debtId) // Method to delete a debt by its ID
        {
            var debtID = _debts.FirstOrDefault(d =>  d.debtId == debtId);
            if (debtID == null)
                return true;
            _debts.Remove(debtID); // Removes debt with the given ID
            SaveDebt(_debts); // Save updated debt list
            return true;
        }

        public async Task<bool> UpdateDebt(Guid debtId, Debt debt) // Method to update a debt by its ID
        {
            var updateDebtID = _debts.FirstOrDefault( ud => ud.debtId == debtId);
            if (updateDebtID != null)
            {
                // updates debt properties
                updateDebtID.debtBalance = debt.debtBalance;
                updateDebtID.debtSource = debt.debtSource;
                updateDebtID.debtTag = debt.debtTag;
                updateDebtID.debtStatus = debt.debtStatus;
                updateDebtID.debtRemark = debt.debtRemark;
                updateDebtID.debtTakken = debt.debtTakken;
                updateDebtID.debtDue = debt.debtDue;
                SaveDebt(_debts); // Save the updated debt list
                return true;
            }
            return false;
        }
        public int PendingDebt() // Method to calculate total pending debt
        {
            var debtAmount = GetAllDebt(); // Filtets debts based on Pending status and sum thier balances
            return PendingAmount = debtAmount.Where(dA => dA.debtStatus == DebtStatus.Pending).Sum(dA => dA.debtBalance);
        }
        public int ClearedDebt() // Method to calculate total cleared debt
        {
            var debtAmount = GetAllDebt(); // Filtets debts based on Cleared status and sum thier balances
            return ClearedAmount = debtAmount.Where(dA => dA.debtStatus == DebtStatus.Cleared).Sum(dA => dA.debtBalance);
        }
    }
}
