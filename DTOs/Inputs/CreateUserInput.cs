namespace contasoft_api.DTOs.Inputs
{
    public class CreateUserInput
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Cellphone { get; set; }
        public string? Password { get; set; }
        public string? Username { get; set; }
        public int? PlanId { get; set; }
    }
}
