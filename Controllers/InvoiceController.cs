using contasoft_api.Data;
using contasoft_api.DTOs;
using contasoft_api.DTOs.Inputs;
using contasoft_api.Interfaces;
using contasoft_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //[HttpGet("607/{id}")]
        //public async Task<IActionResult> GetAll607ByCompany(int companyID)
        //{

        //    var response = new DefaultResponse();
        //    var ListaDeFacturas = new List<Invoice607>();
        //    if (_context.O607 == null)
        //    {
        //        return NotFound();
        //    }

        //    try
        //    {
        //       var Operacion607 = await _context.O607.Where(x => x.CompanyId == companyID).ToListAsync();

        //        foreach (var maestro in Operacion607)
        //        {
        //           var facturas = await _context.Invoice607.Where(x => x.O607Id == maestro.Id && x.IsActive).ToListAsync();
        //            ListaDeFacturas.AddRange(facturas);
        //        }

        //        response.Data = ListaDeFacturas;
        //        response.Message = "Success";
        //        response.StatusCode = 1;
        //        response.Success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message = "Error al obtener las facturas.";
        //        response.StatusCode = 0;
        //        response.Success = false;

        //    }
        //    return Ok(response);
        //}
        //[HttpPost("607")]
        //public async Task<IActionResult> CreateInvoice607(Invoice607Input input)
        //{

        //    var response = new DefaultResponse();
        //    var anomesActual = DateTime.Now.ToString("yyyy/MM");
        //    var Operacion607 = new O607();
        //    if (_context.O607 == null)
        //    {
        //        return NotFound();
        //    }
        //    try
        //    {    var company = await _context.Company.FindAsync(input.CompanyID);
        //         Operacion607=  await _context.O607.Where(x => x.CompanyId == company.Id).LastOrDefaultAsync();

        //        if(Operacion607 == null || DateTime.Parse(anomesActual) > DateTime.Parse(Operacion607.YearMonth))
        //        {
        //            Operacion607.YearMonth = anomesActual;
        //            Operacion607.Amount = 0;
        //            Operacion607.CompanyId = input.CompanyID;
        //            Operacion607.Name = $@"607-{company.Name}-{Operacion607.YearMonth}";
        //            Operacion607.CreateDate = DateTime.Now;
        //            Operacion607.UserCode = "root";
        //            Operacion607.IsActive = false;

        //            await _context.O607.AddAsync(Operacion607);
        //            await _context.SaveChangesAsync();
        //        }


        //        Invoice607 Invoice = new Invoice607()
        //        {
        //            RNCCédulaPasaporte = input.RNCCédulaPasaporte,
        //            TipoIdentificación = input.TipoIdentificación,
        //            NumeroComprobanteFiscal = input.NumeroComprobanteFiscal,
        //            NumeroComprobanteFiscalModificado = input.NumeroComprobanteFiscalModificado,
        //            TipoIngreso = input.TipoIngreso,
        //            FechaComprobante = input.FechaComprobante,
        //            FechaRetención = input.FechaRetención,
        //            MontoFacturado = input.MontoFacturado,
        //            ITBISFacturado = input.ITBISFacturado,
        //            ITBISRetenidoporTerceros = input.ITBISRetenidoporTerceros,
        //            ITBISPercibido = input.ITBISPercibido,
        //            RetenciónRentaporTerceros = input.RetenciónRentaporTerceros,
        //            ISRPercibido = input.ITBISPercibido,
        //            ImpuestoSelectivoalConsumo = input.ImpuestoSelectivoalConsumo,
        //            OtrosImpuestos_Tasas = input.OtrosImpuestos_Tasas,
        //            MontoPropinaLegal = input.MontoPropinaLegal,
        //            Efectivo = input.Efectivo,
        //            Cheque_Transferencia_Depósito = input.Cheque_Transferencia_Depósito,
        //            TarjetaDébito_Crédito = input.TarjetaDébito_Crédito,
        //            VentaACrédito = input.VentaACrédito,
        //            BonosOCertificadosRegalo = input.BonosOCertificadosRegalo,
        //            Permuta = input.Permuta,
        //            OtrasFormasVentas = input.OtrasFormasVentas,
        //            O607Id = Operacion607.Id,
        //            UserCode="root",
        //            CreateDate = DateTime.Now,
        //            IsActive=true

        //        };

        //        await _context.Invoice607.AddAsync(Invoice);
        //        response.Data = "Agregado Corrrectamente";
        //        response.Message = "Success";
        //        response.StatusCode = 1;
        //        response.Success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message = "Error al registrar esta factura.";
        //        response.StatusCode = 0;
        //        response.Success = false;

        //    }
        //    return Ok(response);
        //}
        [HttpGet("{companyID}")]
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
       

        [HttpPost]
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
                    Operacion606.CompanyId = (int)input.CompanyID;
                    Operacion606.Name = $@"607-{company.Name}-{Operacion606.YearMonth}";
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
                response.Data = "Agregado Corrrectamente";
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
                var CountInvoice = await _context.Invoice606.Where(x=>x.O606Id == Operacion606.Id && x.IsActive).CountAsync();
                var company = await _context.Company.FindAsync(data.CompanyID);

                if (Operacion606 == null)
                {
                    Operacion606 = new O606();
                    Operacion606.YearMonth = data.Anomes;
                    Operacion606.Amount = CountInvoice;
                    Operacion606.CompanyId = data.CompanyID;
                    Operacion606.Name = $@"606-{company.Name}-{Operacion606.YearMonth}";
                    Operacion606.CreateDate = DateTime.Now;
                    Operacion606.UserCode = "root";
                    Operacion606.IsActive = true;

                    await _context.O606.AddAsync(Operacion606);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Operacion606.Amount = CountInvoice;
                    Operacion606.IsActive = true;
                     _context.O606.Update(Operacion606);
                    await _context.SaveChangesAsync();
                }


               // response.Data = Operacion606;
                response.Message = "Success";
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
        public async Task<IActionResult> Descargar606xlsx(Descargar606Input model)
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
                    if (model.Formato == 23)
                    {

                        var documento = _generador606.Generate606xlsx(invoices, Operacion606);
                        response.Data = File(documento, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{Operacion606.Name}.xlsx");
                    }
                    else if(model.Formato == 19)
                    {
                        //descargar txt
                    }

                }
                else
                {
                   
                }


                // response.Data = Operacion606;
                response.Message = "Success";
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
    }
}
