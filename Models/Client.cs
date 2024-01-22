namespace contasoft_api.Models
{
    public class Client: AuditLog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Code { get; set; }
        public decimal? Salary { get; set; }
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
