namespace contasoft_api.Models
{
    public class AuditLog
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public bool IsActive { get; set; }
    }
}
