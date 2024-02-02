using contasoft_api.Data;
using contasoft_api.DTOs;
using contasoft_api.DTOs.Inputs;
using contasoft_api.Interfaces;
using contasoft_api.Models;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Packaging;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace contasoft_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ContaSoftDbContext _context;
        private readonly IGenerador607 _generador607;
        private readonly IGenerador606 _generador606;
        public InvoiceController(ContaSoftDbContext context, IGenerador607 generador607, IGenerador606 generador606)
        {
            _context = context;
            _generador607 = generador607;
            _generador606 = generador606;
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
                var Operacion606 = await _context.O607.Where(x => x.CompanyId == companyID).ToListAsync();

                foreach (var maestro in Operacion606)
                {
                    var facturas = await _context.Invoice607.Where(x => x.O607Id == maestro.Id && x.IsActive).ToListAsync();
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
            var anomesActual = DateTime.Now.ToString("yyyy/MM");
            var Operacion607 = new O607();
            if (_context.O607 == null)
            {
                return NotFound();
            }
            try
            {
                var company = await _context.Company.FindAsync(input.CompanyID);
                Operacion607 = await _context.O607.Where(x => x.CompanyId == company.Id).OrderBy(x => x.Id).LastOrDefaultAsync();

                if (Operacion607 == null || DateTime.Parse(anomesActual) > DateTime.Parse(Operacion607.YearMonth))
                {
                    Operacion607 = new O607();
                    Operacion607.YearMonth = anomesActual;
                    Operacion607.Amount = 1;
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
                    RNCCédulaPasaporte = input.RNCCedulaPasaporte,
                    TipoIdentificación = input.TipoIdentificación,
                    NumeroComprobanteFiscal = input.NumeroComprobanteFiscal,
                    NumeroComprobanteFiscalModificado = input.NumeroComprobanteFiscalModificado,
                    TipoIngreso = input.TipoIngreso,
                    FechaComprobante = input.FechaComprobante,
                    FechaRetención = input.FechaRetención,
                    MontoFacturado = input.MontoFacturado,
                    ITBISFacturado = input.ITBISFacturado,
                    ITBISRetenidoporTerceros = input.ITBISRetenidoporTerceros,
                    ITBISPercibido = input.ITBISPercibido,
                    RetenciónRentaporTerceros = input.RetenciónRentaporTerceros,
                    ISRPercibido = input.ITBISPercibido,
                    ImpuestoSelectivoalConsumo = input.ImpuestoSelectivoalConsumo,
                    OtrosImpuestos_Tasas= input.OtrosImpuestos_Tasas,
                    MontoPropinaLegal = input.MontoPropinaLegal,
                    Efectivo = input.Efectivo,
                    Cheque_Transferencia_Depósito = input.Cheque_Transferencia_Depósito,
                    TarjetaDébito_Crédito = input.TarjetaDébito_Crédito,
                    VentaACrédito = input.VentaACrédito,
                    BonosOCertificadosRegalo = input.BonosOCertificadosRegalo,
                    Permuta = input.Permuta,
                    OtrasFormasVentas = input.OtrasFormasVentas,
                    UserCode = "root",
                    CreateDate = DateTime.Now,
                    IsActive = true

                };

                await _context.Invoice607.AddAsync(Invoice);
                await _context.SaveChangesAsync();
                response.Data = "Factura registrada con éxito";
                response.Message = "Success";
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
                var Operacion607 = await _context.O607.Where(x => x.CompanyId == companyID).ToListAsync();

                response.Data = Operacion607;
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
        public async Task<IActionResult> Create607(Generar607Input data){
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
                    Operacion607.Amount = 0;
                    Operacion607.CompanyId = data.CompanyID;
                    Operacion607.Name = $@"607-{company.Name}-{Operacion607.YearMonth.Replace("/", "")}";
                    Operacion607.CreateDate = DateTime.Now;
                    Operacion607.UserCode = "root";
                    Operacion607.IsActive = true;

                    await _context.O607.AddAsync(Operacion607);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var CountInvoice = await _context.Invoice607.Where(x => x.O607Id == Operacion607.Id && x.IsActive).CountAsync();

                    Operacion607.Amount = CountInvoice;
                    Operacion607.IsActive = true;
                    _context.O607.Update(Operacion607);
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
        public async Task<IActionResult> Descargar607(Descargar607Input model)
        {
            var response = new DefaultResponse();
            var ListaDeFacturas = new List<Invoice607>();
            if (_context.O607 == null)
            {
                return NotFound();
            }

            try
            {
                var Operacion607 = await _context.O607.Where(x => x.Id == model.O607Id && x.IsActive).FirstOrDefaultAsync();


                if (Operacion607 != null)
                {
                    var invoices = await _context.Invoice607.Where(x => x.O607Id == model.O607Id && x.IsActive).ToListAsync();
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
                    response.Message = $"607 no encontrado id:{model.O607Id},formato:{model.Formato} ";
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
                    var facturas = await _context.Invoice606.Where(x => x.O606Id == maestro.Id && x.IsActive).ToListAsync();
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
            var anomesActual = DateTime.Now.ToString("yyyy/MM");
            var Operacion606 = new O606();
            if (_context.O606 == null)
            {
                return NotFound();
            }
            try
            {
                var company = await _context.Company.FindAsync(input.CompanyID);
                Operacion606 = await _context.O606.Where(x => x.CompanyId == company.Id).OrderBy(x => x.Id).LastOrDefaultAsync();

                if (Operacion606 == null || DateTime.Parse(anomesActual) > DateTime.Parse(Operacion606.YearMonth))
                {
                    Operacion606 = new O606();
                    Operacion606.YearMonth = anomesActual;
                    Operacion606.Amount = 1;
                    Operacion606.RNC = company.RNC;
                    Operacion606.CompanyId = (int)input.CompanyID;
                    Operacion606.Name = $@"607-{company.Name}-{Operacion606.YearMonth.Replace("/","")}";
                    Operacion606.CreateDate = DateTime.Now;
                    Operacion606.UserCode = "root";
                    Operacion606.IsActive = false;

                    await _context.O606.AddAsync(Operacion606);
                    await _context.SaveChangesAsync();
                }


                Invoice606 Invoice = new Invoice606()
                {
                    RNCCedulaPasaporte = input.RNCCedulaPasaporte,
                    TipoID = (int) input.TipoID,
                    TipoBienesYServiciosComprados = (int)input.TipoBienesYServiciosComprados,
                    NumeroComprobanteFiscal = input.NumeroComprobanteFiscal,
                    NumeroComprobanteFiscalModificado = input.NumeroComprobanteFiscalModificado,
                    FechaComprobante=input.FechaComprobante,
                    FechaPago=input.FechaPago,
                    MontoFacturadoEnServicio=input.MontoFacturadoEnServicio,
                    MontoFacturadoEnBienes=input.MontoFacturadoEnBienes,
                    TotalMontoFacturado=input.TotalMontoFacturado,
                    ITBISFacturado=input.ITBISFacturado,
                    ITBISRetenido=input.ITBISRetenido,
                    ITBISSujetoaProporcionalidad=input.ITBISSujetoaProporcionalidad,
                    ITBISLlevadoAlCosto=input.ITBISLlevadoAlCosto,
                    ITBISPorAdelantar=input.ITBISPorAdelantar,
                    ITBISPersividoEnCompras =input.ITBISPersividoEnCompras,
                    TipoRetencionEnISR  =input.TipoRetencionEnISR,
                    MontoRetencionRenta=input.MontoRetencionRenta,
                    IRSPercibidoEnCompras=input.IRSPercibidoEnCompras,
                    ImpuestoSelectivoAlConsumo=input.ImpuestoSelectivoAlConsumo,
                    OtrosImpuestosTasa=input.OtrosImpuestosTasa,
                    MontoPropinaLegal=input.MontoPropinaLegal,
                    FormaDePago=input.FormaDePago,
                    O606Id = Operacion606.Id,
                    UserCode = "root",
                    CreateDate = DateTime.Now,
                    IsActive = true

                };

                await _context.Invoice606.AddAsync(Invoice);
                await _context.SaveChangesAsync();
                response.Data = "Factura registrada con éxito";
                response.Message = "Success";
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
                var Operacion606 = await _context.O606.Where(x => x.CompanyId == companyID).ToListAsync();

                response.Data = Operacion606;
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

        [HttpPost("606")]
        public async Task<IActionResult> Create606(Generar606Input data)
        {
            var response = new DefaultResponse();
            var ListaDeFacturas = new List<Invoice606>();
            if (_context.O606 == null)
            {
                return NotFound();
            }

            try
            {
                var Operacion606 = await _context.O606.Where(x => x.CompanyId == data.CompanyID && x.YearMonth== data.Anomes).FirstOrDefaultAsync();
                var company = await _context.Company.FindAsync(data.CompanyID);

                if (Operacion606 == null)
                {
                    Operacion606 = new O606();
                    Operacion606.RNC = data.RNC;
                    Operacion606.YearMonth = data.Anomes;
                    Operacion606.Amount = 0;
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
                    var CountInvoice = await _context.Invoice606.Where(x => x.O606Id == Operacion606.Id && x.IsActive).CountAsync();

                    Operacion606.Amount = CountInvoice;
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
        public async Task<IActionResult> Descargar606(Descargar606Input model)
        {
            var response = new DefaultResponse();
            var ListaDeFacturas = new List<Invoice606>();
            if (_context.O606 == null)
            {
                return NotFound();
            }

            try
            {
                var Operacion606 = await _context.O606.Where(x => x.Id == model.O606Id && x.IsActive).FirstOrDefaultAsync();
              

                if (Operacion606 != null)
                {
                    var invoices = await _context.Invoice606.Where(x => x.O606Id == model.O606Id && x.IsActive).ToListAsync();
                    if (invoices ==null)
                    {
                        invoices = new List<Invoice606> { };
                    }
                    if (model.Formato == 23)
                    {
                        try
                        {
                           var document=  _generador606.Generate606xlsx(invoices, Operacion606);
                            response.Data= File(document, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Operacion606.Name +".xlsx");


                        }
                        catch (Exception r)
                        {

                            throw;
                        }
                      
                    }
                    else if(model.Formato == 19)
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

    
    }
    public class Descargar606Input
    {
        public int O606Id { get; set; }
        public int Formato { get; set; }
    }
    public class Generar606Input
    {
        public int CompanyID { get; set; }
        public string Anomes { get; set; }
        public string RNC { get; set; }
    }
    public class Descargar607Input
    {
        public int O607Id { get; set; }
        public int Formato { get; set; }
    }
    public class Generar607Input
    {
        public int CompanyID { get; set; }
        public string Anomes { get; set; }
        public string RNC { get; set; }
    }
}
