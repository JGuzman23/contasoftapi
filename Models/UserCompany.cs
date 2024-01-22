namespace contasoft_api.Models
{
    public class UserCompany:AuditLog
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
    }
}
