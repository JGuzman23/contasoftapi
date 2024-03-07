namespace contasoft_api.DTOs.Inputs
{
    public class BankInput
    {
        public int BankSelectedID { get; set; }
        public int Id { get; set; }
        public string? AccountNumber { get; set;}
        public int CompanyId { get; set;}
        public string? AccountName { get; set; }
        public int? AccountTypeID { get; set; }
        public decimal? InitialBalance { get; set; }
        public int? CurrencyID { get; set; }
    }
}
