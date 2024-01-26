using contasoft_api.Models;

namespace contasoft_api.Interfaces
{
    public  interface IGenerador607
    {
        byte[] Generate607xlsx(List<Invoice607>? dataList, O607 data);
        string Generador607txt(List<Invoice607> dataList, O607 data);
    }
}
