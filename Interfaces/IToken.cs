using contasoft_api.DTOs.Outputs;

namespace contasoft_api.Interfaces
{
    public interface IToken
    {
        Task GenerateToken(LoginOutput dto);
    }
}
