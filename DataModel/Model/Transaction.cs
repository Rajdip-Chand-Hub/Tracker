namespace DataModel.Model
{
    public class Transaction
    {
        public Guid transactionId {  get; set; }

        public int balance { get; set; }

        public string source { get; set; } = string.Empty; 

        public string transactionType { get; set; } = string.Empty ;

        public string tag { get; set; } = string.Empty;

        public string remark { get; set; } = string .Empty;

    }
}