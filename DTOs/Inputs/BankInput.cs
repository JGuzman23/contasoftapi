namespace contasoft_api.DTOs.Inputs
{
    public class BankInput
    {
        public int BankSelectedID { get; set; }
        public int Id { get; set; }
        public string? AccountNumber { get; set;}
        public int CompanyId { get; set;}
    }
}
