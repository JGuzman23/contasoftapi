namespace contasoft_api.Models
{
    public class Currency:AuditLog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
