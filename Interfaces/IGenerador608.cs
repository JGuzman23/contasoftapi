using contasoft_api.Controllers;
using contasoft_api.Models;

namespace contasoft_api.Interfaces
{
    public interface IGenerador608
    {
        byte[] Generate608xlsx(List<DataList608>? dataList, O608 data);
        string Generador608txt(List<DataList608> dataList, O608 data);
    }
}
