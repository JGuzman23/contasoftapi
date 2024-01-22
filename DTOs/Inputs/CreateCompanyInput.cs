namespace contasoft_api.DTOs.Inputs
{
    public class CreateCompanyInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RNC { get; set; }
        public string? Address { get; set; }
        public string? Telefono { get; set; }
        public byte[]? Photo { get; set; }
        public int UserId { get; set; }
    }
}
