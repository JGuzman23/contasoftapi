namespace contasoft_api.Models
{
    public class InvoiceIncome:AuditLog
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public string InvoiceNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public int Invoice607Id { get; set; }
        public bool Deleted { get; set; }
        public string? Status { get; set; }
        public List<InvoiceProduct> Products { get; set; }
        public virtual Invoice607 Invoice607 { get; set; }

    }
}
