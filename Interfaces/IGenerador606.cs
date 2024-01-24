using contasoft_api.Models;

namespace contasoft_api.Interfaces
{
    public interface IGenerador606
    {
        MemoryStream Generate606xlsx(List<Invoice606>? dataList, O606 data);
    }
}
