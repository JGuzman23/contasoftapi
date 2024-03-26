using contasoft_api.Data;
using contasoft_api.DTOs.Inputs;
using contasoft_api.DTOs.Outputs;
using contasoft_api.DTOs;
using contasoft_api.Interfaces;
using contasoft_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace contasoft_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class O608Controller : ControllerBase
    {
        private readonly ContaSoftDbContext _context;
        private readonly IGenerador608 _generador608;

        public O608Controller(ContaSoftDbContext context, IGenerador608 generador608)
        {
            _context = context;
            _generador608 = generador608;
        }

        [HttpGet("608/{companyID}")]
        public async Task<IActionResult> GetAll608ByCompany(int companyID)
        {
            var response = new DefaultResponse();
            if (_context.O606 == null)
            {
                return NotFound();
            }

            try
            {
                List<O608Output> result = new List<O608Output>();

                var Operacion608s = await _context.O608.Where(x => x.CompanyId == companyID && x.IsActive).ToListAsync();

                foreach (var Operacion608 in Operacion608s)
                {

                    var Invoices = await _context.VoidInvoice.Where(x => x.O608Id == Operacion608.Id).CountAsync();

                    O608Output output = new O608Output
                    {
                        Id = Operacion608.Id,
                        Name = Operacion608.Name,
                        YearMonth = Operacion608.YearMonth,
                        Amount = Invoices,
                        RNC = Operacion608.RNC,
                        IsActive = Operacion608.IsActive,
                        CreateDate = Operacion608.CreateDate,
                    };

                    result.Add(output);

                }

                response.Data = result;
                response.Message = "Success";
                response.StatusCode = 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error al obtener los 606.";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }

        [HttpPost("608")]
        public async Task<IActionResult> Create608(O608input data)
        {
            var response = new DefaultResponse();
            var O608s = new List<O606Output>();
            if (_context.O608 == null)
            {
                return NotFound();
            }

            try
            {
                var invoicesVoid = await _context.VoidInvoice.Where(x => x.CompanyId == data.CompanyID && x.IsActive).ToListAsync();
                var O608FromDB = await _context.O608.Where(x => x.CompanyId == data.CompanyID && x.YearMonth == data.Anomes).FirstOrDefaultAsync();
                var company = await _context.Company.FindAsync(data.CompanyID);

                if (O608FromDB == null)
                {
                    O608FromDB = new O608()
                    {
                        Name = $@"608-{company.Name}-{data.Anomes.Replace("/", "")}",
                        YearMonth = data.Anomes,
                        RNC = data.RNC,
                        CompanyId = data.CompanyID,
                        IsActive = true,
                        UserCode = "Root",
                        CreateDate = DateTime.Now,

                    };
                    await _context.O608.AddAsync(O608FromDB);
                    await _context.SaveChangesAsync();

                }

                foreach (var item in invoicesVoid)
                {
                    item.O608Id = O608FromDB.Id;
                    item.IsActive = false;
                }

                _context.VoidInvoice.UpdateRange(invoicesVoid);
                await _context.SaveChangesAsync();

                response.Message = "608 creado con éxito!";
                response.StatusCode = 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error generar el 608.";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }

        [HttpPost("descargar/608")]
        public async Task<IActionResult> Descargar608(DescargarInput model)
        {
            var response = new DefaultResponse();
            var ListaDeFacturas = new List<Invoice606>();
            var invoices = new List<DataList608> { };

            try
            {
                var Operacion608 = await _context.O608.Where(x => x.Id == model.Id && x.IsActive).FirstOrDefaultAsync();


                if (Operacion608 != null)
                {
                    var invoicesVoid = await _context.VoidInvoice.Where(x => x.O608Id == Operacion608.Id && x.IsActive).ToListAsync();

                    foreach (var item in invoicesVoid)
                    {
                        var invoice = await _context.Invoice607.Where(x => x.Id == item.InvoiceId).FirstOrDefaultAsync();

                        DataList608 dataList = new DataList608
                        {
                            NCF = invoice.NumeroComprobanteFiscal,
                            FechaComprobante = invoice.FechaComprobante,
                            TipoAnulacionID = item.Tipo
                        };

                        invoices.Add(dataList);
                    }

                    if (invoices == null)
                    {
                        invoices = new List<DataList608> { };
                    }
                    if (model.Formato == 23)
                    {
                        try
                        {
                            var document = _generador608.Generate608xlsx(invoices, Operacion608);
                            response.Data = File(document, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Operacion608.Name + ".xlsx");


                        }
                        catch (Exception r)
                        {

                            throw;
                        }

                    }
                    else if (model.Formato == 19)
                    {

                        string archivo = _generador608.Generador608txt(invoices, Operacion608);
                        response.Data = archivo;
                    }

                }
                else
                {

                }


                // response.Data = Operacion606;
                response.Message = "608 descargado con éxito!";
                response.StatusCode = 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error descargar el 608.";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }

        [HttpPost("anular")]
        public async Task<IActionResult> VoidInvoice(AnularInput input)
        {
            var response = new DefaultResponse();
            if (_context.VoidInvoice == null)
            {
                return NotFound();
            }

            try
            {
                var invoice = await _context.Invoice607.FindAsync(input.InvoiceId);
                if (invoice != null)
                {
                    invoice.Status = "Anulada";
                    invoice.IsActive = false;
                    _context.Invoice607.Update(invoice);
                    await _context.SaveChangesAsync();

                    var anomesActual = DateTime.Now.ToString("yyyy/MM");
                    var company = await _context.Company.FindAsync(input.CompanyID);

                    var o608 = await _context.O608.Where(x => x.CompanyId == input.CompanyID).OrderBy(x => x.Id).LastOrDefaultAsync();

                    VoidInvoice voidInvoice = new VoidInvoice()
                    {
                        Tipo = input.Tipo,
                        Comment = input.Comment,
                        InvoiceId = input.InvoiceId,
                        CompanyId = input.CompanyID,
                        CreateDate = DateTime.Now,
                        UserCode = "root",
                        IsActive = true
                    };

                    if (o608 != null)
                    {
                        voidInvoice.O608Id = o608.Id;
                    }
                    else
                    {
                        O608 newO608 = new O608()
                        {
                            Name = $@"608-{company.Name}-{anomesActual.Replace("/", "")}",
                            YearMonth = anomesActual,
                            RNC = company.RNC,
                            CompanyId = company.Id,
                            IsActive = true,
                            UserCode = "Root",
                            CreateDate = DateTime.Now,

                        };
                        await _context.O608.AddAsync(newO608);
                        await _context.SaveChangesAsync();

                        voidInvoice.O608Id = newO608.Id;
                    }


                    await _context.VoidInvoice.AddAsync(voidInvoice);
                    await _context.SaveChangesAsync();
                    response.Message = "Factura Anulada éxito!";
                    response.StatusCode = 1;
                    response.Success = true;

                }
                else
                {
                    response.Message = "Error al Obtener la Factura.";
                    response.StatusCode = 0;
                    response.Success = false;
                }




            }
            catch (Exception ex)
            {
                response.Message = "Error al Anular la Factura.";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }
    }

    public class DataList608
    {
        public string NCF { get; set; }
        public string FechaComprobante { get; set; }
        public int TipoAnulacionID { get; set; }
        public string Status { get; set; }
    }
}
