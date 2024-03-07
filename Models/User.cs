namespace contasoft_api.Models
{
    public class User: AuditLog
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Cellphone { get; set; }
        public string? Password { get; set; }
        public string? Username { get; set;}
        public int? RolId { get; set; }
        public int? PlanId { get; set; }
        public virtual Plan? Plan { get; set; }

    }

}
