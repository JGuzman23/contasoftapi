namespace contasoft_api.DTOs.Inputs
{
    public class InvoiceProductInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal Total { get; set; }
    }
}
