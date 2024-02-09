namespace contasoft_api.Models
{
    public class VoidInvoice: AuditLog
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int Tipo { get; set; }
        public string Comment { get; set; }
        public int CompanyId { get; set; }
        public int O608Id { get; set; }
    }
}
