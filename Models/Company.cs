namespace contasoft_api.Models
{
    public class Company : AuditLog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  RNC { get; set; }
        public string? Address { get; set; }
        public string? Telefono { get; set; }
        public byte[]? Photo { get; set; }

    }
}
