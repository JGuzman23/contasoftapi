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
    public class O606Controller : ControllerBase
    {
        private readonly ContaSoftDbContext _context;
        private readonly IGenerador606 _generador606;

        public O606Controller(ContaSoftDbContext context, IGenerador606 generador606)
        {
            _context = context;
            _generador606 = generador606;
        }

        [HttpGet("invoice606/{companyID}")]
        public async Task<IActionResult> GetAllInvoice606ByCompany(int companyID)
        {
            var response = new DefaultResponse();
            var ListaDeFacturas = new List<Invoice606>();
            if (_context.O606 == null)
            {
                return NotFound();
            }

            try
            {
                var Operacion606 = await _context.O606.Where(x => x.CompanyId == companyID).ToListAsync();

                foreach (var maestro in Operacion606)
                {
                    var facturas = await _context.Invoice606.Where(x => x.O606Id == maestro.Id && x.IsActive && x.Deleted == false).ToListAsync();
                    ListaDeFacturas.AddRange(facturas);
                }

                response.Data = ListaDeFacturas;
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

        [HttpPost("invoice606")]
        public async Task<IActionResult> CreateInvoice606(Invoice606Input input)
        {


            var response = new DefaultResponse();
            var anomesFactura = DateTime.Parse(input.FechaComprobante).ToString("yyyy/MM");
            var Operacion606 = new O606();
            if (_context.O606 == null)
            {
                return NotFound();
            }
            try
            {
                var company = await _context.Company.FindAsync(input.CompanyID);
                Operacion606 = await _context.O606.Where(x => x.CompanyId == company.Id && x.YearMonth == anomesFactura).OrderBy(x => x.Id).FirstOrDefaultAsync();

                if (Operacion606 == null)
                {
                    Operacion606 = new O606();
                    Operacion606.YearMonth = anomesFactura;
                    Operacion606.RNC = company.RNC;
                    Operacion606.CompanyId = (int)input.CompanyID;
                    Operacion606.Name = $@"607-{company.Name}-{Operacion606.YearMonth.Replace("/", "")}";
                    Operacion606.CreateDate = DateTime.Now;
                    Operacion606.UserCode = "root";
                    Operacion606.IsActive = false;

                    await _context.O606.AddAsync(Operacion606);
                    await _context.SaveChangesAsync();
                }

                Invoice606 Invoice = new Invoice606()
                {
                    RNCCedulaPasaporte = input.RNCCedulaPasaporte,
                    TipoID = (int)input.TipoID,
                    TipoBienesYServiciosComprados = (int)input.TipoBienesYServiciosComprados,
                    NumeroComprobanteFiscal = input.NumeroComprobanteFiscal,
                    NumeroComprobanteFiscalModificado = input.NumeroComprobanteFiscalModificado,
                    FechaComprobante = input.FechaComprobante,
                    FechaPago = input.FechaPago,
                    MontoFacturadoEnServicio = input.MontoFacturadoEnServicio,
                    MontoFacturadoEnBienes = input.MontoFacturadoEnBienes,
                    TotalMontoFacturado = input.TotalMontoFacturado,
                    ITBISFacturado = input.ITBISFacturado,
                    ITBISRetenido = input.ITBISRetenido,
                    ITBISSujetoaProporcionalidad = input.ITBISSujetoaProporcionalidad,
                    ITBISLlevadoAlCosto = input.ITBISLlevadoAlCosto,
                    ITBISPorAdelantar = input.ITBISPorAdelantar,
                    ITBISPersividoEnCompras = input.ITBISPersividoEnCompras,
                    TipoRetencionEnISR = input.TipoRetencionEnISR,
                    MontoRetencionRenta = input.MontoRetencionRenta,
                    IRSPercibidoEnCompras = input.IRSPercibidoEnCompras,
                    ImpuestoSelectivoAlConsumo = input.ImpuestoSelectivoAlConsumo,
                    OtrosImpuestosTasa = input.OtrosImpuestosTasa,
                    MontoPropinaLegal = input.MontoPropinaLegal,
                    FormaDePago = input.FormaDePago,
                    O606Id = Operacion606.Id,
                    UserCode = "root",
                    CreateDate = DateTime.Now,
                    IsActive = true,
                    Deleted = false


                };

                await _context.Invoice606.AddAsync(Invoice);
                await _context.SaveChangesAsync();


                response.Message = "Factura registrada con éxito";
                response.StatusCode = 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error al registrar esta factura.";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }

        [HttpGet("606/{companyID}")]
        public async Task<IActionResult> GetAll606ByCompany(int companyID)
        {
            var response = new DefaultResponse();
            var ListaDeFacturas = new List<Invoice606>();
            if (_context.O606 == null)
            {
                return NotFound();
            }

            try
            {
                List<O606Output> result = new List<O606Output>();

                var Operacion606s = await _context.O606.Where(x => x.CompanyId == companyID && x.IsActive).ToListAsync();


                foreach (var Operacion606 in Operacion606s)
                {
                    var totalInvoiced = 0.00m;
                    var ItbisTotal = 0.00m;

                    var Invoices = await _context.Invoice606.Where(x => x.O606Id == Operacion606.Id && x.IsActive && x.Deleted == false).ToListAsync();

                    foreach (var invoice in Invoices)
                    {
                        totalInvoiced += (decimal)invoice.TotalMontoFacturado;
                        ItbisTotal += (decimal)invoice.ITBISFacturado;
                    }

                    O606Output output = new O606Output
                    {
                        Id = Operacion606.Id,
                        Name = Operacion606.Name,
                        YearMonth = Operacion606.YearMonth,
                        Amount = Invoices.Count(),
                        ITBISTotal = ItbisTotal,
                        InvoicedAmount = totalInvoiced,
                        RNC = Operacion606.RNC,
                        IsActive = Operacion606.IsActive,
                        CreateDate = Operacion606.CreateDate,
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

        [HttpPost("606")]
        public async Task<IActionResult> Create606(O606input data)
        {
            var response = new DefaultResponse();
            var ListaDeFacturas = new List<Invoice606>();
            if (_context.O606 == null)
            {
                return NotFound();
            }

            try
            {
                var Operacion606 = await _context.O606.Where(x => x.CompanyId == data.CompanyID && x.YearMonth == data.Anomes).FirstOrDefaultAsync();
                var company = await _context.Company.FindAsync(data.CompanyID);

                if (Operacion606 == null)
                {
                    Operacion606 = new O606();
                    Operacion606.RNC = data.RNC;
                    Operacion606.YearMonth = data.Anomes;
                    Operacion606.CompanyId = data.CompanyID;
                    Operacion606.Name = $@"606-{company.Name}-{Operacion606.YearMonth.Replace("/", "")}";
                    Operacion606.CreateDate = DateTime.Now;
                    Operacion606.UserCode = "root";
                    Operacion606.IsActive = true;

                    await _context.O606.AddAsync(Operacion606);
                    await _context.SaveChangesAsync();
                    response.Message = "606 creado con éxito!";
                    response.StatusCode = 1;
                    response.Success = true;
                }
                else
                {
                    if (Operacion606.IsActive)
                    {
                        response.Message = "Este 606 ya existe!";
                        response.StatusCode = 0;
                        response.Success = false;
                    }
                    else
                    {
                        Operacion606.IsActive = true;
                        _context.O606.Update(Operacion606);
                        await _context.SaveChangesAsync();
                        response.Message = "606 creado con éxito!";
                        response.StatusCode = 1;
                        response.Success = true;
                    }


                }


                // response.Data = Operacion606;


            }
            catch (Exception ex)
            {
                response.Message = "Error generar el 606.";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }

        [HttpPost("descargar/606")]
        public async Task<IActionResult> Descargar606(DescargarInput model)
        {
            var response = new DefaultResponse();
            var ListaDeFacturas = new List<Invoice606>();
            if (_context.O606 == null)
            {
                return NotFound();
            }

            try
            {
                var Operacion606 = await _context.O606.Where(x => x.Id == model.Id && x.IsActive).FirstOrDefaultAsync();


                if (Operacion606 != null)
                {
                    var invoices = await _context.Invoice606.Where(x => x.O606Id == model.Id && x.IsActive).ToListAsync();
                    if (invoices == null)
                    {
                        invoices = new List<Invoice606> { };
                    }
                    if (model.Formato == 23)
                    {
                        try
                        {
                            var document = _generador606.Generate606xlsx(invoices, Operacion606);
                            response.Data = File(document, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Operacion606.Name + ".xlsx");


                        }
                        catch (Exception r)
                        {

                            throw;
                        }

                    }
                    else if (model.Formato == 19)
                    {

                        string archivo = _generador606.Generador606txt(invoices, Operacion606);
                        response.Data = archivo;
                    }

                }
                else
                {

                }


                // response.Data = Operacion606;
                response.Message = "606 descargado con éxito!";
                response.StatusCode = 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error descargar el 606.";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }

        [HttpPut("invoice606/{id}")]
        public async Task<IActionResult> UpdateInvoice606(int id, Invoice606Input input)
        {
            if (id != input.Id)
            {
                return BadRequest();
            }
            var response = new DefaultResponse();
            var anomesFactura = DateTime.Parse(input.FechaComprobante).ToString("yyyy/MM");

            if (_context.Invoice606 == null)
            {
                return NotFound();
            }
            try
            {
                var Operacion606 = await _context.O606.Where(x => x.CompanyId == input.CompanyID && x.YearMonth == anomesFactura).OrderBy(x => x.Id).FirstOrDefaultAsync();
                var invoice = await _context.Invoice606.FindAsync(id);


                try
                {
                    if (invoice != null)
                    {
                        invoice.RNCCedulaPasaporte = input.RNCCedulaPasaporte;
                        invoice.TipoID = (int)input.TipoID;
                        invoice.TipoBienesYServiciosComprados = (int)input.TipoBienesYServiciosComprados;
                        invoice.NumeroComprobanteFiscal = input.NumeroComprobanteFiscal;
                        invoice.NumeroComprobanteFiscalModificado = input.NumeroComprobanteFiscalModificado;
                        invoice.FechaComprobante = input.FechaComprobante;
                        invoice.FechaPago = input.FechaPago;
                        invoice.MontoFacturadoEnServicio = input.MontoFacturadoEnServicio;
                        invoice.MontoFacturadoEnBienes = input.MontoFacturadoEnBienes;
                        invoice.TotalMontoFacturado = input.TotalMontoFacturado;
                        invoice.ITBISFacturado = input.ITBISFacturado;
                        invoice.ITBISRetenido = input.ITBISRetenido;
                        invoice.ITBISSujetoaProporcionalidad = input.ITBISSujetoaProporcionalidad;
                        invoice.ITBISLlevadoAlCosto = input.ITBISLlevadoAlCosto;
                        invoice.ITBISPorAdelantar = input.ITBISPorAdelantar;
                        invoice.ITBISPersividoEnCompras = input.ITBISPersividoEnCompras;
                        invoice.TipoRetencionEnISR = input.TipoRetencionEnISR;
                        invoice.MontoRetencionRenta = input.MontoRetencionRenta;
                        invoice.IRSPercibidoEnCompras = input.IRSPercibidoEnCompras;
                        invoice.ImpuestoSelectivoAlConsumo = input.ImpuestoSelectivoAlConsumo;
                        invoice.OtrosImpuestosTasa = input.OtrosImpuestosTasa;
                        invoice.MontoPropinaLegal = input.MontoPropinaLegal;
                        invoice.FormaDePago = input.FormaDePago;
                        invoice.O606Id = Operacion606.Id;
                        invoice.UserCode = "root";
                        invoice.UpdateDate = DateTime.Now;

                        _context.Invoice606.Update(invoice);
                        await _context.SaveChangesAsync();
                    }


                }
                catch (Exception)
                {

                    throw;
                }


                response.Message = "Factura Actualizada con éxito";
                response.StatusCode = 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error al Actualizar esta factura.";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }

        [HttpDelete("invoice606/{id}")]
        public async Task<IActionResult> DeleteInvoice606(int id)
        {
            var response = new DefaultResponse();

            try
            {
                var invoice = await _context.Invoice606.FindAsync(id);
                invoice.Deleted = true;
                invoice.UpdateDate = DateTime.Now;
                _context.Invoice606.Update(invoice);
                await _context.SaveChangesAsync();


                response.Message = "Factura Eliminada con éxito";
                response.StatusCode = 1;
                response.Success = true;

            }
            catch (Exception)
            {
                response.Message = "Success";
                response.StatusCode = 1;
                response.Success = true;

            }

            return Ok(response);
        }
    }
    public class DescargarInput
    {
        public int Id { get; set; }
        public int Formato { get; set; }
    }
}
