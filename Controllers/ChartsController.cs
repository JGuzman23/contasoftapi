using contasoft_api.Data;
using contasoft_api.DTOs;
using contasoft_api.DTOs.Outputs;
using contasoft_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace contasoft_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly ContaSoftDbContext _context;

        public ChartsController(ContaSoftDbContext context)
        {
            _context = context;
        }

        [HttpGet("{companyID}")]
        public async Task<IActionResult> GetAmountCompany(int companyID)
        {

            var response = new DefaultResponse();
            var ListaDataCharts = new List<DataChartsOutput>();
            if (_context.O607 == null)
            {
                return NotFound();
            }

            try
            {
                var utlimafecha = DateTime.Now.AddMonths(-5).Date;
              

                while(utlimafecha <= DateTime.Now.Date)
                {
                    var YearMonth = utlimafecha.ToString("yyyy/MM");
                    DataChartsOutput dataChartsOutput = new DataChartsOutput();
                    var Operacion607 = await _context.O607.Where(x => x.CompanyId == companyID && x.YearMonth== YearMonth).ToListAsync();
                    var Operacion606 = await _context.O606.Where(x => x.CompanyId == companyID && x.YearMonth== YearMonth).ToListAsync();
                    var MontoTotalIngresos = 0.0m;
                    var MontoTotalGastos = 0.0m;
                    foreach (var maestro in Operacion607)
                    {
                        
                        var facturas = await _context.Invoice607.Where(x => x.O607Id == maestro.Id && x.IsActive).ToListAsync();

                        foreach (var montos in facturas)
                        {
                            MontoTotalIngresos += (decimal)montos.MontoFacturado;
                        }

                    }
                    dataChartsOutput.MontoTotalIngresos = MontoTotalIngresos;
                    foreach (var maestro in Operacion606)
                    {
                       
                        var facturas = await _context.Invoice606.Where(x => x.O606Id == maestro.Id && x.IsActive && x.Deleted == false).ToListAsync();

                        foreach (var montos in facturas)
                        {
                            MontoTotalGastos += (decimal)montos.TotalMontoFacturado;
                        }

                    }
                    dataChartsOutput.MontoTotalGastos = MontoTotalGastos;
                    ListaDataCharts.Add(dataChartsOutput);
                   utlimafecha= utlimafecha.AddMonths(1);

                }

               

                response.Data = ListaDataCharts;
                response.Message = "Success";
                response.StatusCode = 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error al obtener las facturas.";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }

    }
}
