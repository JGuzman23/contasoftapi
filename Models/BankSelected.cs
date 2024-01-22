namespace contasoft_api.Models
{
    public class BankSelected:AuditLog
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public string AccountNumber { get; set; }
        public int CompanyId { get; set; }

        public virtual Bank Bank { get; set; }
        public virtual Company Company { get; set; }

    }
}
