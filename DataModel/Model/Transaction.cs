namespace DataModel.Model
{
    public class Transaction
    {
        public Guid transactionId {  get; set; }

        public int balance { get; set; }

        public string source { get; set; } = string.Empty; 

        public TransactionType transactionType { get; set; }

        public Tags tag{ get; set; }   

        public string remark { get; set; } = string .Empty;

        public DateOnly created { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    }
}