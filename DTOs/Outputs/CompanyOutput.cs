namespace contasoft_api.DTOs.Outputs
{
    public class CompanyOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RNC { get; set; }
        public string? Address { get; set; }
        public string? Telefono { get; set; }
        public string? Photo { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
