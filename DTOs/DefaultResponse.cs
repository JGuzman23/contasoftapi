namespace contasoft_api.DTOs
{
    public class DefaultResponse
    {
        public string Message { get; set; } 
        public int StatusCode { get; set; } 
        public bool Success { get; set; } 
        public object? Data { get; set; }
    }
}
