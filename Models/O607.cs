namespace contasoft_api.Models
{
    public class O607 : AuditLog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? YearMonth { get; set; }
        public int Amount { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
