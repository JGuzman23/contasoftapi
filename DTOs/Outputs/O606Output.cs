namespace contasoft_api.DTOs.Outputs
{
    public class O606Output
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? YearMonth { get; set; }
        public int Amount { get; set; }
        public decimal? ITBISTotal { get; set; } = 0.00m;
        public decimal? InvoicedAmount { get; set; } = 0.00m;
        public string? RNC { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }

    }
}
