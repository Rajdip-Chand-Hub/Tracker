namespace DataModel.Model
{
    public class Debt
    {
        public Guid debtId { get; set; }

        public int debtBalance { get; set; }

        public string debtSource { get; set; } = string.Empty;

        public DebtTags debtTag { get; set; }

        public DebtStatus debtStatus { get; set; }

        public string debtRemark { get; set; } = string.Empty;

        public DateOnly debtTakken { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public DateOnly debtDue { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}