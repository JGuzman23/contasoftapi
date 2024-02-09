namespace contasoft_api.DTOs.Outputs
{
    public class O608Output
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? YearMonth { get; set; }
        public int Amount { get; set; }
        public string? RNC { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }

    }
}
