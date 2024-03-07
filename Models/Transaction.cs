namespace contasoft_api.Models
{
    public class Transaction:AuditLog
    {
        public int Id { get; set; }
        public string? BankNumberOut { get; set; }
        public string? BankNumberIn { get; set; }
        public decimal Amount { get; set; }
        public string NoCheck { get; set;}
        public string Concept { get; set;}
        public string Tipo { get; set; }
        public DateTime TransactionDate { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }



    }
}
