namespace contasoft_api.DTOs.Outputs
{
    public class BankOutput
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? AccountNumber { get; set; }
        public int BankSelectedID { get; set; }
        public string? AccountName { get; set; }
        public int? AccountTypeID { get; set; }
        public decimal? InitialBalance { get; set; }
        public int? CurrencyID { get; set; }
    }
}
