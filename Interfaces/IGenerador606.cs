using contasoft_api.Models;

namespace contasoft_api.Interfaces
{
    public interface IGenerador606
    {
        byte[] Generate606xlsx(List<Invoice606>? dataList, O606 data);
        string Generador606txt(List<Invoice606> dataList, O606 data);
    }
}
