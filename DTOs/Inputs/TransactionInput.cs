using contasoft_api.Models;

namespace contasoft_api.DTOs.Inputs
{
    public class TransactionInput
    {
        public int? Id { get; set; }
        public string? BankNumberOut { get; set; }
        public string? BankNumberIn { get; set; }
        public decimal? Amount { get; set; }
        public string? NoCheck { get; set; }
        public string? Concept { get; set; }
        public string? Tipo { get; set; }
        public string? TransactionDate { get; set; }
        public int? CompanyId { get; set; }
      

    }
}
