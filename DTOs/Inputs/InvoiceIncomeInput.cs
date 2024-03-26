using contasoft_api.Models;

namespace contasoft_api.DTOs.Inputs
{
    public class InvoiceIncomeInput
    {
        public int Id { get; set; }
        public string? Note { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public int? Invoice607Id { get; set; }
        public bool? Deleted { get; set; }
        public string? Status { get; set; }
        public int? CompanyID { get; set; }
        public List<InvoiceProductInput>? Products { get; set; }
        public virtual Invoice607Input? Invoice607 { get; set; }
    }
}
