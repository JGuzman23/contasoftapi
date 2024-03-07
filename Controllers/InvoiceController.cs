using contasoft_api.Data;
using contasoft_api.DTOs;
using contasoft_api.DTOs.Inputs;
using contasoft_api.DTOs.Outputs;
using contasoft_api.Interfaces;
using contasoft_api.Models;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Packaging;
using System.ComponentModel.Design;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace contasoft_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ContaSoftDbContext _context;
        private readonly IGenerador607 _generador607;
        private readonly IGenerador606 _generador606;
        private readonly IGenerador608 _generador608;

        public InvoiceController(ContaSoftDbContext context, IGenerador607 generador607, IGenerador606 generador606, IGenerador608 generador608)
        {
            _context = context;
            _generador607 = generador607;
            _generador606 = generador606;
            _generador608 = generador608;
        }


        [HttpGet("invoice607/{companyID}")]
        public async Task<IActionResult> GetAllInvoice607ByCompany(int companyID)
        {

            var response = new DefaultResponse();
            var ListaDeFacturas = new List<Invoice607>();
            if (_context.O607 == null)
            {
                return NotFound();
            }

            try
            {
                var Operacion607 = await _context.O607.Where(x => x.CompanyId == companyID).ToListAsync();

                foreach (var maestro in Operacion607)
                {
                    var facturas = await _context.Invoice607.Where(x => x.O607Id == maestro.Id && x.IsActive && x.Deleted == false).ToListAsync();
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

        [HttpPost("invoice607")]
        public async Task<IActionResult> CreateInvoice607(Invoice607Input input)
        {
            var response = new DefaultResponse();
            var anomesFactura = DateTime.Parse(input.FechaComprobante).ToString("yyyy/MM");
            var Operacion607 = new O607();
            if (_context.O607 == null)
            {
                return NotFound();
            }
            try
            {
                VerificarPropiedadesNulas(input);
                var company = await _context.Company.FindAsync(input.CompanyID);
                Operacion607 = await _context.O607.Where(x => x.CompanyId == company.Id && x.YearMonth == anomesFactura).OrderBy(x => x.Id).FirstOrDefaultAsync();


                if (Operacion607 == null)
                {
                    Operacion607 = new O607();
                    Operacion607.YearMonth = anomesFactura;
                   
                    Operacion607.RNC = company.RNC;
                    Operacion607.CompanyId = (int)input.CompanyID;
                    Operacion607.Name = $@"607-{company.Name}-{Operacion607.YearMonth.Replace("/", "")}";
                    Operacion607.CreateDate = DateTime.Now;
                    Operacion607.UserCode = "root";
                    Operacion607.IsActive = false;

                    await _context.O607.AddAsync(Operacion607);
                    await _context.SaveChangesAsync();
                }
              


                Invoice607 Invoice = new Invoice607()
                {
                    RNCCedulaPasaporte = input.RNCCedulaPasaporte,
                    TipoIdentificación = input.TipoIdentificacion,
                    NumeroComprobanteFiscal = input.NumeroComprobanteFiscal,
                    NumeroComprobanteFiscalModificado = input.NumeroComprobanteFiscalModificado,
                    TipoIngreso = input.TipoIngreso,
                    FechaComprobante = input.FechaComprobante,
                    FechaRetención = input.FechaRetencion,
                    MontoFacturado = input.MontoFacturado,
                    ITBISFacturado = input.ITBISFacturado,
                    ITBISRetenidoporTerceros = input.ITBISRetenidoporTerceros,
                    ITBISPercibido = input.ITBISPercibido,
                    RetenciónRentaporTerceros = input.RetencionRentaporTerceros,
                    ISRPercibido = input.ITBISPercibido,
                    ImpuestoSelectivoalConsumo = input.ImpuestoSelectivoalConsumo,
                    OtrosImpuestos_Tasas = input.OtrosImpuestos_Tasas,
                    MontoPropinaLegal = input.MontoPropinaLegal,
                    Efectivo = input.Efectivo,
                    Cheque_Transferencia_Depósito = input.Cheque_Transferencia_Deposito,
                    TarjetaDébito_Crédito = input.TarjetaDebito_Credito,
                    VentaACrédito = input.VentaACredito,
                    BonosOCertificadosRegalo = input.BonosOCertificadosRegalo,
                    Permuta = input.Permuta,
                    OtrasFormasVentas = input.OtrasFormasVentas,
                    UserCode = "root",
                    CreateDate = DateTime.Now,
                    IsActive = true,
                    Deleted = false,
                    O607Id = Operacion607.Id

                };

                await _context.Invoice607.AddAsync(Invoice);
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


        [HttpGet("607/{companyID}")]
        public async Task<IActionResult> GetAll607ByCompany(int companyID)
        {

            var response = new DefaultResponse();
            var ListaDeFacturas = new List<Invoice607>();
            if (_context.O607 == null)
            {
                return NotFound();
            }

            try
            {
                List<O607Output> result = new List<O607Output>();

                var Operacion607s = await _context.O607.Where(x => x.CompanyId == companyID && x.IsActive).ToListAsync();


                foreach (var Operacion607 in Operacion607s)
                {
                    var totalInvoiced = 0.00m;
                    var ItbisTotal = 0.00m;

                    var Invoices = await _context.Invoice607.Where(x => x.O607Id == Operacion607.Id && x.IsActive && x.Deleted == false).ToListAsync();

                    foreach (var invoice in Invoices)
                    {
                        totalInvoiced += (decimal)invoice.MontoFacturado;
                        ItbisTotal += (decimal)invoice.ITBISFacturado;
                    }

                    O607Output output = new O607Output
                    {
                        Id = Operacion607.Id,
                        Name = Operacion607.Name,
                        YearMonth = Operacion607.YearMonth,
                        Amount = Invoices.Count(),
                        ITBISTotal = ItbisTotal,
                        InvoicedAmount = totalInvoiced,
                        RNC = Operacion607.RNC,
                        IsActive = Operacion607.IsActive,
                        CreateDate = Operacion607.CreateDate,



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
                response.Message = "Error al obtener las facturas.";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }

        [HttpPost("607")]
        public async Task<IActionResult> Create607(Generar607Input data)
        {
            var response = new DefaultResponse();
            var ListaDeFacturas = new List<Invoice606>();
            if (_context.O606 == null)
            {
                return NotFound();
            }

            try
            {
                var Operacion607 = await _context.O607.Where(x => x.CompanyId == data.CompanyID && x.YearMonth == data.Anomes).FirstOrDefaultAsync();
                var company = await _context.Company.FindAsync(data.CompanyID);

                if (Operacion607 == null)
                {
                    Operacion607 = new O607();
                    Operacion607.RNC = data.RNC;
                    Operacion607.YearMonth = data.Anomes;
                    Operacion607.CompanyId = data.CompanyID;
                    Operacion607.Name = $@"607-{company.Name}-{Operacion607.YearMonth.Replace("/", "")}";
                    Operacion607.CreateDate = DateTime.Now;
                    Operacion607.UserCode = "root";
                    Operacion607.IsActive = true;

                    await _context.O607.AddAsync(Operacion607);
                    await _context.SaveChangesAsync();
                }



                // response.Data = Operacion606;
                response.Message = "607 creado con éxito!";
                response.StatusCode = 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error generar el 607.";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }

        [HttpPost("descargar/607")]
        public async Task<IActionResult> Descargar607(DescargarInput model)
        {
            var response = new DefaultResponse();
            var ListaDeFacturas = new List<Invoice607>();
            if (_context.O607 == null)
            {
                return NotFound();
            }

            try
            {
                var Operacion607 = await _context.O607.Where(x => x.Id == model.Id && x.IsActive).FirstOrDefaultAsync();


                if (Operacion607 != null)
                {
                    var invoices = await _context.Invoice607.Where(x => x.O607Id == model.Id && x.IsActive).ToListAsync();
                    if (invoices == null)
                    {
                        invoices = new List<Invoice607> { };
                    }
                    if (model.Formato == 23)
                    {
                        try
                        {
                            var document = _generador607.Generate607xlsx(invoices, Operacion607);
                            response.Data = File(document, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Operacion607.Name + ".xlsx");


                        }
                        catch (Exception r)
                        {

                            throw;
                        }

                    }
                    else if (model.Formato == 19)
                    {

                        string archivo = _generador607.Generador607txt(invoices, Operacion607);
                        response.Data = archivo;
                    }

                }
                else
                {
                    response.Message = $"607 no encontrado id:{model.Id},formato:{model.Formato} ";
                }


                // response.Data = Operacion606;
                response.Message = "607 descargado con éxito!";
                response.StatusCode = 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = $"Error descargar el 607. {ex.Message}";
                response.StatusCode = 0;
                response.Success = false;

            }
            return Ok(response);
        }

        [HttpPut("invoice607/{id}")]
        public async Task<IActionResult> UpdateInvoice607(int id, Invoice607Input input)
        {
            if (id != input.Id)
            {
                return BadRequest();
            }
            var response = new DefaultResponse();
            var anomesFactura = DateTime.Parse(input.FechaComprobante).ToString("yyyy/MM");

            if (_context.Invoice607 == null)
            {
                return NotFound();
            }
            try
            {
                var Operacion606 = await _context.O607.Where(x => x.CompanyId == input.CompanyID && x.YearMonth == anomesFactura).OrderBy(x => x.Id).FirstOrDefaultAsync();
                var invoice = await _context.Invoice607.FindAsync(id);


                try
                {
                    if (invoice != null)
                    {
                        invoice.RNCCedulaPasaporte = input.RNCCedulaPasaporte;
                        invoice.TipoIdentificación = input.TipoIdentificacion;
                        invoice.NumeroComprobanteFiscal = input.NumeroComprobanteFiscal;
                        invoice.NumeroComprobanteFiscalModificado = input.NumeroComprobanteFiscalModificado;
                        invoice.TipoIngreso = input.TipoIngreso;
                        invoice.FechaComprobante = input.FechaComprobante;
                        invoice.FechaRetención = input.FechaRetencion;
                        invoice.MontoFacturado = input.MontoFacturado;
                        invoice.ITBISFacturado = input.ITBISFacturado;
                        invoice.ITBISRetenidoporTerceros = input.ITBISRetenidoporTerceros;
                        invoice.ITBISPercibido = input.ITBISPercibido;
                        invoice.RetenciónRentaporTerceros = input.RetencionRentaporTerceros;
                        invoice.ISRPercibido = input.ITBISPercibido;
                        invoice.ImpuestoSelectivoalConsumo = input.ImpuestoSelectivoalConsumo;
                        invoice.OtrosImpuestos_Tasas = input.OtrosImpuestos_Tasas;
                        invoice.MontoPropinaLegal = input.MontoPropinaLegal;
                        invoice.Efectivo = input.Efectivo;
                        invoice.Cheque_Transferencia_Depósito = input.Cheque_Transferencia_Deposito;
                        invoice.TarjetaDébito_Crédito = input.TarjetaDebito_Credito;
                        invoice.VentaACrédito = input.VentaACredito;
                        invoice.BonosOCertificadosRegalo = input.BonosOCertificadosRegalo;
                        invoice.Permuta = input.Permuta;
                        invoice.OtrasFormasVentas = input.OtrasFormasVentas;
                        invoice.UserCode = "root";
                        invoice.UpdateDate = DateTime.Now;

                        _context.Invoice607.Update(invoice);
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

        [HttpDelete("invoice607/{id}")]
        public async Task<IActionResult> DeleteInvoice607(int id)
        {
            var response = new DefaultResponse();

            try
            {
                var invoice = await _context.Invoice607.FindAsync(id);
                invoice.Deleted = true;
                invoice.UpdateDate = DateTime.Now;
                _context.Invoice607.Update(invoice);
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

        //operaciones 606

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

                    var Invoices = await _context.Invoice606.Where(x => x.O606Id == Operacion606.Id && x.IsActive && x.Deleted== false).ToListAsync();

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
                }
                else
                {

                    Operacion606.IsActive = true;
                    _context.O606.Update(Operacion606);
                    await _context.SaveChangesAsync();
                }


                // response.Data = Operacion606;
                response.Message = "606 creado con éxito!";
                response.StatusCode = 1;
                response.Success = true;
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
                var  Operacion606 = await _context.O606.Where(x => x.CompanyId == input.CompanyID && x.YearMonth == anomesFactura).OrderBy(x => x.Id).FirstOrDefaultAsync();
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

        //operacion 608

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
                var O608FromDB = await _context.O608.Where(x => x.CompanyId == data.CompanyID && x.YearMonth== data.Anomes).FirstOrDefaultAsync();
                var company = await _context.Company.FindAsync(data.CompanyID);

                if (O608FromDB == null)
                {
                    O608FromDB = new O608()
                    {
                        Name= $@"608-{company.Name}-{data.Anomes.Replace("/", "")}",
                        YearMonth= data.Anomes,
                        RNC = data.RNC,
                        CompanyId = data.CompanyID,
                        IsActive = true,
                        UserCode="Root",
                        CreateDate = DateTime.Now,

                     };
                    await _context.O608.AddAsync(O608FromDB);
                    await  _context.SaveChangesAsync();

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
                    var invoicesVoid = await _context.VoidInvoice.Where(x => x.O608Id == model.Id && x.IsActive).ToListAsync();

                    foreach (var item in invoicesVoid)
                    {
                        var invoice =await _context.Invoice607.Where(x=>x.Id == item.InvoiceId).FirstOrDefaultAsync();

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
                if (invoice !=null)
                {
                    invoice.IsActive = false;
                    _context.Invoice607.Update(invoice);
                    await _context.SaveChangesAsync();

                    var anomesActual = DateTime.Now.ToString("yyyy/MM");

                    var o608 = await _context.O608.Where(x => x.CompanyId == input.CompanyID).OrderBy(x => x.Id).LastOrDefaultAsync();

                    if (o608 != null) {
                    
                        if(DateTime.Parse(o608.YearMonth).ToString("yyyy/MM") != anomesActual)
                        {
                            o608.Id = 0;
                        }
                    }
                    VoidInvoice voidInvoice = new VoidInvoice()
                    {
                        Tipo = input.Tipo,
                        Comment = input.Comment,
                        InvoiceId = input.InvoiceId,
                        CompanyId = input.CompanyID,
                        CreateDate = DateTime.Now,
                        O608Id = o608.Id,
                        UserCode = "root",
                        IsActive = true
                    };

                    await _context.VoidInvoice.AddAsync(voidInvoice);
                    await _context.SaveChangesAsync();
                    // response.Data = Operacion606;
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

        public static void VerificarPropiedadesNulas<T>(T entidad)
        {
            var propiedades = typeof(T).GetProperties();

            foreach (var propiedad in propiedades)
            {

                if (propiedad.PropertyType == typeof(string) && propiedad.GetValue(entidad) == null)
                {
                    propiedad.SetValue(entidad, "");
                }
                else if (propiedad.PropertyType == typeof(int) && propiedad.GetValue(entidad) == null)
                {
                    propiedad.SetValue(entidad, 0);
                }
                else if (propiedad.PropertyType == typeof(decimal) && propiedad.GetValue(entidad) == null)
                {
                    propiedad.SetValue(entidad, 0m);
                }
                else if (propiedad.PropertyType == typeof(double) && propiedad.GetValue(entidad) == null)
                {
                    propiedad.SetValue(entidad, 0.0);
                }
            }
        }

    }
   
   
    public class DescargarInput
    {
        public int Id { get; set; }
        public int Formato { get; set; }
    }
    public class Generar607Input
    {
        public int CompanyID { get; set; }
        public string Anomes { get; set; }
        public string RNC { get; set; }
    }

    public class DataList608
    {
        public string NCF { get; set; }
        public string FechaComprobante { get; set; }
        public int TipoAnulacionID { get; set; }
        public string Status { get; set; }
    }
}
